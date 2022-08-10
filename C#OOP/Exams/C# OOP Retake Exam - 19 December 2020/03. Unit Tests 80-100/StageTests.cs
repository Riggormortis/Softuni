// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
  
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void CtorShouldInitializeAllCollections()
	    {
			Stage stage = new Stage();

			Assert.IsNotNull(stage.Performers);
		}

		[Test]
		public void ValidatePerformer()
        {
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(
			() => stage.AddPerformer(null));

			//Performer performer1 = new Performer("Gencho", "Penchev", 16);

			//Assert.Throws<ArgumentException>(() =>
			//	stage.AddPerformer(performer1));

			Assert.Throws<ArgumentException>(() =>
			{
				//Arange and Act
				Performer performer1 = new Performer("Gencho", "Penchev", 16);
				stage.AddPerformer(performer1);
			},
			   //Assert
			   "You can only add performers that are at least 18.");

			Performer performer2 = new Performer("Tencho", "Penchev", 18);
			stage.AddPerformer(performer2);

			Assert.AreEqual(1, stage.Performers.Count);
			Assert.True(stage.Performers.Any(x => x == performer2));
		}

        [Test]
		public void ValidateAddSong()
        {
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() =>
			{
				//Arange and Act
				stage.AddSong(null);
			},
			   //Assert
			   "Can not be null!");

			Song song = new Song("Without me", TimeSpan.FromSeconds(20));

			Assert.Throws<ArgumentException>(() =>
			{
				//Arange and Act
				stage.AddSong(song);
			},
			   //Assert
			   "You can only add songs that are longer than 1 minute.");


			Song song1 = new Song("Without you", TimeSpan.FromSeconds(120));

			stage.AddSong(song1);

			

		}

        [Test]
		public void ValidateNullorNonExistentAddSongToPerformer()
        {
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() =>
			{
				//Arange and Act
				stage.AddSongToPerformer(null, "test");
			},
			   //Assert
			   "Can not be null!");

			Assert.Throws<ArgumentNullException>(() =>
			{
				//Arange and Act
				stage.AddSongToPerformer("test", null);
			},
			   //Assert
			   "Can not be null!");

			Assert.Throws<ArgumentNullException>(() =>
			{
				//Arange and Act
				stage.AddSongToPerformer("test", null);
			},
			   //Assert
			   "Can not be null!");


			Assert.Throws<ArgumentException>(() =>
			{
				//Arange and Act
				stage.AddSongToPerformer("songName", "noOne");
			},
			   //Assert
			   "There is no performer with this name.");

			Performer performer2 = new Performer("Tencho", "Penchev", 18);
			stage.AddPerformer(performer2);

			Assert.Throws<ArgumentException>(() =>
			{
				//Arange and Act
				stage.AddSongToPerformer("songName", "Tencho Penchev");
			},
			   //Assert
			   "There is no song with this name.");
		}

		[Test]
		public void ValidateValidAddSongToPerformer()
		{
			Stage stage = new Stage();
			Performer performer2 = new Performer("Tencho", "Penchev", 18);
			stage.AddPerformer(performer2);
			Song song1 = new Song("Without you", TimeSpan.FromSeconds(120));

			stage.AddSong(song1);

			stage.AddSongToPerformer($"{song1.Name}", performer2.FullName);

			string result = $"{song1.Name} will be performed by {performer2.FullName}";

			Assert.True(performer2.SongList.Contains(song1));
			Assert.AreEqual("Without you will be performed by Tencho Penchev", result);
		}

        [Test]
		public void ValidatePlay()
        {
			Stage stage = new Stage();
			Performer performer1 = new Performer("Tencho", "Penchev", 18);
			Performer performer2 = new Performer("Gencho", "Latev", 25);
			Performer performer3 = new Performer("Vanko", "Petrov", 35);

			Song song1 = new Song("test", TimeSpan.FromSeconds(120));
			Song song2 = new Song("Without me", TimeSpan.FromSeconds(160));
			Song song3 = new Song("Without you", TimeSpan.FromSeconds(250));
			Song song4 = new Song("Mamma mia", TimeSpan.FromSeconds(240));
			Song song5 = new Song("Moriro da Re", TimeSpan.FromSeconds(240));
			Song song6 = new Song("Hope", TimeSpan.FromSeconds(240));

			stage.AddPerformer(performer1);
			stage.AddPerformer(performer2);
			stage.AddPerformer(performer3);

			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddSong(song3);
			stage.AddSong(song4);
			stage.AddSong(song5);
			stage.AddSong(song6);

			stage.AddSongToPerformer(song1.Name, performer1.FullName);
			stage.AddSongToPerformer(song2.Name, performer1.FullName);
			stage.AddSongToPerformer(song3.Name, performer3.FullName);
			stage.AddSongToPerformer(song4.Name, performer3.FullName);
			stage.AddSongToPerformer(song5.Name, performer3.FullName);
			stage.AddSongToPerformer(song6.Name, performer3.FullName);


			string result = stage.Play();
			string expected = $"{stage.Performers.Count} performers played 6 songs";

			Assert.AreEqual(expected, result);
				

		}

	}
}