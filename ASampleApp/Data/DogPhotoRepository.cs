using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using SQLite;

using ASampleApp.Models;


namespace ASampleApp.Data
{
	public class DogPhotoRepository
	{
		public DogPhotoRepository()
		{
			IfEmptyCheckCosmosDB();
		}

		private void IfEmptyCheckCosmosDB()
		{
			var list = new List<Dog> { };
            list = this.GetAllDogsPhoto();

			if (!list.Any())
			{
                var myListOfCosmosDogs = Task.Run(async () => await CosmosDB.CosmosDBServicePhoto.GetAllCosmosDogs()).Result;
				foreach (var item in myListOfCosmosDogs)
				{
					var tempDog = CosmosDB.DogConverter.ConvertToDog(item);
					this.AddNewDogPhotoSourcePhoto(tempDog.Name, tempDog.FurColor, tempDog.DogPictureSource);

                    App.MyDogListPhotoPage.MyViewModel._observableCollectionOfDogs.Add(tempDog);
				}
			}
		}

		private SQLiteConnection sqliteConnection;

		public DogPhotoRepository(string dbPath)
		{
			sqliteConnection = new SQLiteConnection(dbPath);
			sqliteConnection.CreateTable<Dog>();
		}

		public void AddNewDogPhoto(string name, string furColor)
		{
			sqliteConnection.Insert(new Dog
			{
				Name = name,
				FurColor = furColor,
				//a default dog image for entries via the text only field
				DogPictureSource = "https://s-media-cache-ak0.pinimg.com/736x/4b/c2/ac/4bc2acd1af5130a668a4c391805f3f29--teacup-poodle-puppies-teacup-poodles.jpg"
			});

		}

		public void DeleteDogPhoto(Dog dog)
		{
			sqliteConnection.Delete(dog);

		}

        public void DeleteAllDogsPhoto()
        {
            var query = sqliteConnection.Table<Dog>();   //   Where(v => v.Id > -1);

            foreach (var individualQuery in query)
            {
                sqliteConnection.Delete(individualQuery);
            }
		}

		public void AddNewDogPhotoURLPhoto(string name, string furColor, string dogURL)
		{
			sqliteConnection.Insert(new Dog { Name = name, FurColor = furColor, DogPictureURL = dogURL });
		}

		public void AddNewDogPhotoFilePhoto(string name, string furColor, string dogFile)
		{
			sqliteConnection.Insert(new Dog { Name = name, FurColor = furColor, DogPictureFile = dogFile });
		}

		public void AddNewDogPhotoSourcePhoto(string name, string furColor, string dogSource)
		{
			sqliteConnection.Insert(new Dog { Name = name, FurColor = furColor, DogPictureSource = dogSource });
		}


		public List<Dog> GetAllDogsPhoto()
		{
			return sqliteConnection.Table<Dog>().ToList();
		}

		public Dog GetFirstDogPhoto()
		{
			return sqliteConnection.Table<Dog>().FirstOrDefault();
		}

		public Dog GetLastDogPhoto()
		{
			return sqliteConnection.Table<Dog>().LastOrDefault();

		}


	}
}
