/*using System;
using System.IO;
using System.Media;

namespace TheGame
{
    class SoundPacman
    {
        static String fileNameStart = @"..\..\Sound\StartMusic.wav";
        static String fileNameKilled = @"..\..\Sound\killed.wav";
        static String fileNameEatPill = @"..\..\Sound\EatPill.wav";
        static String fileNameExtralife = @"..\..\Sound\extralife.wav";
        static String fileNameFruiteat = @"..\..\Sound\fruiteat.wav";
        static String fileNameGhosteat = @"..\..\Sound\ghosteat.wav";


        static void StartSound(string fileNameStart)
        {
            SoundPlayer sp = new SoundPlayer(fileNameStart);
            sp.Load();
            sp.Play();

        }

        static void KilledSound(string fileNameKilled)
        {
            SoundPlayer sp = new SoundPlayer(fileNameKilled);
            sp.Load();
            sp.Play();

        }

        static void EatPillSound(string fileNameEatPill)
        {
            SoundPlayer sp = new SoundPlayer(fileNameEatPill);
            sp.Load();
            sp.Play();

        }

        static void ExtralifeSound(string fileNameExtralife)
        {
            SoundPlayer sp = new SoundPlayer(fileNameExtralife);
            sp.Load();
            sp.Play();

        }

        static void FruiteatSound(string fileNameFruiteat)
        {
            SoundPlayer sp = new SoundPlayer(fileNameFruiteat);
            sp.Load();
            sp.Play();

        }

        static void GhosteatSound(string fileNameGhosteat)
        {
            SoundPlayer sp = new SoundPlayer(fileNameGhosteat);
            sp.Load();
            sp.Play();

        }

        static void Main()
        {
            StartSound(fileNameStart);
            KilledSound(fileNameKilled);
            EatPillSound(fileNameEatPill);
            ExtralifeSound(fileNameExtralife);
            FruiteatSound(fileNameFruiteat);
            GhosteatSound(fileNameGhosteat);

        }



        //Second rty:
        /*private SoundPlayer Player = new SoundPlayer();
		private void loadSoundAsync()
		{
			// Note: You may need to change the location specified based on 
			// the location of the sound to be played. 
            this.Player.SoundLocation = @"D:\Telerik\C#2\PacmanGame\BuildProcessTemplates\TheGame\TheGame\Sound\StartMusic.wav";
			this.Player.LoadAsync();
		}
		
		private void Player_LoadCompleted (
            object sender, 
            System.ComponentModel.AsyncCompletedEventArgs e)
		{
		    if (this.Player.IsLoadCompleted)
		    {
		        this.Player.PlaySync();
		    }
		}
        static void Main()
        {
            
        }
    }
}*/
