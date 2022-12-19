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
            CheckForIllegalCrossThreadCalls = false;//�������̷߳��ʿؼ����÷�����Ҫ�Ľ�
        }

        private void startBotton_Click(object sender, EventArgs e)
        {
            if (startBotton.Text == "��ʼ")
            {
                nowGame = new Thread(StartGame)
                {
                    IsBackground = true
                };
                nowGame.Start();
                //StartGame();
            }
            else if(startBotton.Text == "ֹͣ")
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
            startBotton.Text = "ֹͣ";
            try
            {
               Scene nowScene=InitGame();
                var p1 = nowScene.players[0];
                var p2 = nowScene.players[1];
                nameP1.Text = p1.name;
                nameP2.Text = p2.name;

                OutLine("��Ϸ��ʼ");
                
                
                cardStack.Text = nowScene.stackManager.cardsStack.Count.ToString();
                OutPutBox.Text = "";
                hpP1.Text = p1.Hp.ToString();
                handCardP1.Text = p1.handCardsArea.Count.ToString();
                hpP2.Text = p2.Hp.ToString();
                handCardP2.Text = p1.handCardsArea.Count.ToString();
                p1.Draw(nowScene.stackManager.Draw(4));
                p2.Draw(nowScene.stackManager.Draw(4));
                //��Ϸ��ѭ��
                while (true)
                {
                    nowScene.HasToken = p1;
                    while (p1.stage != Stage.Wait) { p1.TakeTurn();}
                    nowScene.HasToken = p2;
                    while (p2.stage != Stage.Wait) { p2.TakeTurn(); }
                    //һ������������ѭ���ĺð취������ҵ��ж�ȫ����Ϊ�¼���GameManager���͡���GameManagerִ��
                }
            }catch (Exception error) when (error is GameOver||error is ThreadInterruptedException)
            {
                startBotton.Text = "��ʼ";
            }
            catch (Exception error)
            {
                OutLine("��Ϸ�߼������˱�����" + error.Message);
            }
            finally
            {
                startBotton.Text = "��ʼ";
            }  
        }
        Scene InitGame()
        {
            //����һЩȫ������
            Player p1 = new(1, characterP1.Text switch { "С��ħ" => new LittleDemon(), "����" => new Youmu(), "�װ�" => new BaiBan(), _ => new BaiBan() }), p2 = new(2, characterP2.Text switch { "С��ħ" => new LittleDemon(), "����" => new Youmu(), "�װ�" => new BaiBan(),_=>new BaiBan() });
            GameManager.Instance.Scene = new Scene() { players = new List<Player> { p1, p2 } };


            GameManager.Instance.Scene.stackManager.StackShuffled += () =>
            {
                cardStack.Text = cardStack.Text = GameManager.Instance.Scene.stackManager.cardsStack.Count.ToString();
                OutLine("�ƶ�ˢ��"); Thread.Sleep((int)(sleepTime / speedControl.Value));
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
                    OutLine($"��{player.name}������!"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                    if (GameManager.Instance.Scene.IsGameEnds()) { throw new GameOver(); }
                };
                player.OnDying += amount =>
                {
                    OutLine($"��{player.name}���������״̬��"); Thread.Sleep((int)(sleepTime / speedControl.Value));
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
                        OutLine($"��{player.name}���ܵ���{source.name}����ɵ�{damage}���˺�����ǰ����:{player.Hp - damage}");
                    }
                    else
                    {
                        OutLine($"��{player.name}���ܵ�{damage}������Դ�˺�����ǰ����:{player.Hp - damage}");
                    }
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.OnGetHeal += (source, amount) =>
                {
                    if (player.id == 1) { hpP1.Text = (int.Parse(hpP1.Text) + amount).ToString(); }
                    else if (player.id == 2) { hpP2.Text = (int.Parse(hpP2.Text) + amount).ToString(); }
                    OutLine($"��{player.name}���ظ�{amount}����������ǰ����:{player.Hp + amount}"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.DrawCard += num =>
                {
                    if (player.id == 1) { handCardP1.Text = (int.Parse(handCardP1.Text) + num).ToString(); }
                    else if (player.id == 2) { handCardP2.Text = (int.Parse(handCardP2.Text) + num).ToString(); }
                    OutLine($"��{player.name}������{num}���ơ�"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.AfterDiscard += cards =>
                {
                    if (player.id == 1) { handCardP1.Text = (int.Parse(handCardP1.Text) - cards.Count).ToString(); }
                    else if (player.id == 2) { handCardP2.Text = (int.Parse(handCardP2.Text) - cards.Count).ToString(); }
                    var names = new List<string>(); foreach (var card in cards) { names.Add(card.Name); }
                    OutLine($"��{player.name}��������{cards.Count}����:{string.Join("��", names)}��");
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.PlayCard += (card, target) =>
                {
                    if (player.id == 1) { handCardP1.Text = (int.Parse(handCardP1.Text) - 1).ToString(); }
                    else if (player.id == 2) { handCardP2.Text = (int.Parse(handCardP2.Text) - 1).ToString(); }
                    OutLine($"��{player.name}���ԡ�{target.name}��ʹ����һ��{card.Name}��");

                    card.Use(player, target);
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.RespondCard += card =>
                {
                    if (player.id == 1) { handCardP1.Text = (int.Parse(handCardP1.Text) - 1).ToString(); }
                    else if (player.id == 2) { handCardP2.Text = (int.Parse(handCardP2.Text) - 1).ToString(); }
                    OutLine( $"��{player.name}�������һ��{card.Name}��");
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.StageStart += () =>
                {
                    OutLine($"��{player.name}���غϿ�ʼ��"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.StageEnd += () =>
                {
                    OutLine($"��{player.name}���غϽ�����"); Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                player.TriggerSkill += skill =>
                {
                    OutLine($"��{player.name}��{skill.strategy switch{SkillStrategy.Positive => "����",SkillStrategy.Passive => "����", _ => throw new NotImplementedException()}}�˼���{skill.name}!");
                    Thread.Sleep((int)(sleepTime / speedControl.Value));
                };
                //��ÿ����ҽ��е�������
                player.skillArea.Add(player.character.skills.ToArray());//�󶨼���
                player.ai =AI.BindAI(player,player.character.name);//��ai
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