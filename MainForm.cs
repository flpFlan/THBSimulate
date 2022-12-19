using System;
using System.Collections;
using System.Numerics;
using System.Reflection;

namespace THBSimulate
{
    public partial class MainForm : Form
    {
        Thread? nowGame;
        decimal sleepTime = 4000;
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//允许子线程访问控件，该方法需要改进
        }

        private void startBotton_Click(object sender, EventArgs e)
        {
            if (startBotton.Text == "开始")
            {
                nowGame = new Thread(StartGame)
                {
                    IsBackground = true
                };
                nowGame.Start();
                //StartGame();
            }
            else if(startBotton.Text == "停止")
            {
                nowGame?.Interrupt();
            }
        }
       public void OutLine(string message)
        {
            OutPutBox.Text+=">>>\r\n"+message+"\r\n";
        }
        public void Out(string message)
        {
            OutPutBox.Text += ">>>\r\n" + message;
        }
        void StartGame()
        {
            startBotton.Text = "停止";
            try
            {
               Scene nowScene=InitGame();
                var p1 = nowScene.players[0];
                var p2 = nowScene.players[1];
                nameP1.Text = p1.name;
                nameP2.Text = p2.name;

                OutLine("游戏开始");
                
                
                cardStack.Text = nowScene.stackManager.cardsStack.Count.ToString();
                OutPutBox.Text = "";
                hpP1.Text = p1.Hp.ToString();
                handCardP1.Text = p1.handCardsArea.Count.ToString();
                hpP2.Text = p2.Hp.ToString();
                handCardP2.Text = p1.handCardsArea.Count.ToString();
                p1.Draw(nowScene.stackManager.Draw(4));
                p2.Draw(nowScene.stackManager.Draw(4));
                //游戏主循环
                while (true)
                {
                    nowScene.HasToken = p1;
                    while (p1.stage != Stage.Wait) { p1.TakeTurn();}
                    nowScene.HasToken = p2;
                    while (p2.stage != Stage.Wait) { p2.TakeTurn(); }
                    //一个死亡后跳出循环的好办法：把玩家的行动全部改为事件向GameManager发送。由GameManager执行
                }
            }catch (Exception error) when (error is GameOver||error is ThreadInterruptedException)
            {
                startBotton.Text = "开始";
            }
            catch (Exception error)
            {
                OutLine("游戏逻辑发生了崩溃！" + error.Message);
            }
            finally
            {
                startBotton.Text = "开始";
            }  
        }
        Scene InitGame()
        {
            //进行一些全局设置
            Player p1 = new(1, characterP1.Text switch { "小恶魔" => new LittleDemon(), "妖梦" => new Youmu(), "白板" => new BaiBan(), _ => new BaiBan() }), p2 = new(2, characterP2.Text switch { "小恶魔" => new LittleDemon(), "妖梦" => new Youmu(), "白板" => new BaiBan(),_=>new BaiBan() });
            GameManager.Instance.Scene = new Scene() { players = new List<Player> { p1, p2 } };


            GameManager.Instance.Scene.stackManager.StackShuffled += () =>
            {
                cardStack.Text = cardStack.Text = GameManager.Instance.Scene.stackManager.cardsStack.Count.ToString();
                OutLine("牌堆刷新"); Thread.Sleep((int)(sleepTime / speedControl.Value));
            };
            GameManager.Instance.Scene.stackManager.CardsStackChanged += amount =>
            {
                cardStack.Text = (int.Parse(cardStack.Text) + amount).ToString();
            };
            foreach (var player in GameManager.Instance.Scene.players)
            {
                player.SendMessage += message =>
                {
                    OutLine(message);
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.Dead += () =>
                {
                    OutLine($"【{player.name}】死亡!"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                    if (GameManager.Instance.Scene.IsGameEnds()) { throw new GameOver(); }
                };
                player.OnDying += amount =>
                {
                    OutLine($"【{player.name}】进入濒死状态。"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                    for (int i = 0; i < amount; i++)
                    {
                        if (player.handCardsArea.Contains<Heal>(out Heal heal)) { player.Play(heal, player); }
                        else { break; }
                    }
                };
                player.OnGetDamage += (source, damage) =>
                {
                    if (player.id == 1) { hpP1.Text = (int.Parse(hpP1.Text) - damage).ToString(); }
                    else if (player.id == 2) { hpP2.Text = (int.Parse(hpP2.Text) - damage).ToString(); }
                    if (source != null)
                    {
                        OutLine($"【{player.name}】受到【{source.name}】造成的{damage}点伤害，当前体力:{player.Hp - damage}");
                    }
                    else
                    {
                        OutLine($"【{player.name}】受到{damage}点无来源伤害，当前体力:{player.Hp - damage}");
                    }
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.OnGetHeal += (source, amount) =>
                {
                    if (player.id == 1) { hpP1.Text = (int.Parse(hpP1.Text) + amount).ToString(); }
                    else if (player.id == 2) { hpP2.Text = (int.Parse(hpP2.Text) + amount).ToString(); }
                    OutLine($"【{player.name}】回复{amount}点体力，当前体力:{player.Hp + amount}"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.DrawCard += num =>
                {
                    if (player.id == 1) { handCardP1.Text = (int.Parse(handCardP1.Text) + num).ToString(); }
                    else if (player.id == 2) { handCardP2.Text = (int.Parse(handCardP2.Text) + num).ToString(); }
                    OutLine($"【{player.name}】摸了{num}张牌。"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.AfterDiscard += cards =>
                {
                    if (player.id == 1) { handCardP1.Text = (int.Parse(handCardP1.Text) - cards.Count).ToString(); }
                    else if (player.id == 2) { handCardP2.Text = (int.Parse(handCardP2.Text) - cards.Count).ToString(); }
                    var names = new List<string>(); foreach (var card in cards) { names.Add(card.Name); }
                    OutLine($"【{player.name}】弃置了{cards.Count}张牌:{string.Join("、", names)}。");
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.PlayCard += (card, target) =>
                {
                    if (player.id == 1) { handCardP1.Text = (int.Parse(handCardP1.Text) - 1).ToString(); }
                    else if (player.id == 2) { handCardP2.Text = (int.Parse(handCardP2.Text) - 1).ToString(); }
                    OutLine($"【{player.name}】对【{target.name}】使用了一张{card.Name}。");

                    card.Use(player, target);
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.RespondCard += card =>
                {
                    if (player.id == 1) { handCardP1.Text = (int.Parse(handCardP1.Text) - 1).ToString(); }
                    else if (player.id == 2) { handCardP2.Text = (int.Parse(handCardP2.Text) - 1).ToString(); }
                    OutLine( $"【{player.name}】打出了一张{card.Name}。");
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.StageStart += () =>
                {
                    OutLine($"【{player.name}】回合开始。"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.StageEnd += () =>
                {
                    OutLine($"【{player.name}】回合结束。"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.TriggerSkill += skill =>
                {
                    OutLine($"【{player.name}】{skill.strategy switch{SkillStrategy.Positive => "发动",SkillStrategy.Passive => "触发", _ => throw new NotImplementedException()}}了技能{skill.name}!");
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                //对每个玩家进行单独设置
                player.skillArea.Add(player.character.skills.ToArray());//绑定技能
                player.ai =AI.BindAI(player,player.character.name);//绑定ai
            }
            
            return GameManager.Instance.Scene;
        }

        private void OutPutBox_TextChanged(object sender, EventArgs e)
        {
            OutPutBox.SelectionStart=OutPutBox.Text.Length;
            OutPutBox.ScrollToCaret();
        }
    }

    class GameOver : Exception
    {
       public GameOver() 
        { 
        
        }
    }
}