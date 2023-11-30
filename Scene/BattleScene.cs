﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public class BattleScene : Scene
    {
        private Monster monster;
        private Player player;
        public BattleScene(Game game) : base(game)
        {
            
        }
        public override void Render()
        {
            // 적 정보 ( 체력 )
            Console.WriteLine($"{monster.name} \nHP : {monster.currentHP} / {monster.maxHP}");
            Console.WriteLine($"DMG : {monster.damage}");
            Console.WriteLine();

            Console.WriteLine($"플레이어 \nHP : {Data.Instance.player.currentHP} / {Data.Instance.player.maxHP}");
            Console.WriteLine($"DMG : {Data.Instance.player.damage}");
            Console.WriteLine();
            // 적 이미지
            // 내 정보 ( 체력, 공격력, 경험치 )
            
            // 내 이미지


        }

        public override void Update()
        {
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 방어");
            Console.Write("명령을 입력하세요 : ");

            string input = Console.ReadLine();

            int command;

            
            if (int.TryParse(input, out command) == false)
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }

            bool isDefense = false;

            switch(command)
            {
                case 1:
                    // 공격
                    // 플레이어가 몬스터에게 행동 (공격)
                    
                    Console.WriteLine($"플레이어가 {monster.name}을 공격하였습니다.");
                    Thread.Sleep(500);
                    
                    monster.currentHP -= player.damage;

                    Console.WriteLine($"플레이어가 {monster.name}에게 {player.damage}의 데미지를 입혔습니다.");
                    Thread.Sleep(500);
                    break;
                case 2:
                    // 방어

                    Console.WriteLine("플레이어가 방어 자세를 취했습니다.");
                    isDefense = true;
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    break;
            }

            // 플레이어 행동 후 몬스터 행동 하기 전에 몬스터 상태 판단


            if(monster.currentHP <= 0)
            {
                // 전투 승리
                EndBattle();
                return;
            }

            // 몬스터 턴

            if(false == isDefense)
            {
                Console.WriteLine($"{monster.name}이/가 플레이어를 공격 하였습니다.");
                Thread.Sleep(500);

                player.currentHP -= monster.damage;

                Console.WriteLine($"{monster.name}이/가 플레이어에게 {monster.damage}의 데미지를 입혔습니다.");
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine($"플레이어가 {monster.name}의 공격을 방어하였습니다.");
                Thread.Sleep(500);
            }

            if (player.currentHP <= 0)
            {
                // 게임 오버
                game.GameOver();
                return;
            }
            
        }

        public void StartBattle(Monster monster)
        {
            Console.Clear();

            this.monster = monster;
            player = Data.Instance.player;

            Console.WriteLine($"{monster.name}과 전투 시작! ");

            Thread.Sleep(1000);
        }

        public void EndBattle()
        {
            Console.Clear();
            
            Console.WriteLine($"{monster.name} 와의 전투에서 승리! ");
            Thread.Sleep(1000);
            player.GainExp(monster.rewardExp);

            monster.DropItem();

            Data.Instance.monsters.Remove(monster); ;


            game.Map();
        }
    }
}