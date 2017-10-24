﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using SQLite;

using ASampleApp.Models;

namespace ASampleApp.Data
{

    //THIS IS FOR DOGLISTMVVMPAGE
	public class DogRepository
	{

        public DogRepository() 
        {
            IfEmptyCheckCosmosDB();
        }

        private void IfEmptyCheckCosmosDB()
        {
            var list = new List<Dog> { };
            list = this.GetAllDogs();

            if (!list.Any()) 
            {
                var myListOfCosmosDogs = Task.Run(async () => await CosmosDB.CosmosDBService.GetAllCosmosDogs()).Result;
                foreach (var item in myListOfCosmosDogs)
                {
                    var tempDog = CosmosDB.DogConverter.ConvertToDog(item);
                    this.AddNewDogPhotoSource(tempDog.Name, tempDog.FurColor, tempDog.DogPictureSource);

                    App.MyDogListMVVMPage.MyViewModel._observableCollectionOfDogs.Add(tempDog);
                }
            }
        }

        private SQLiteConnection sqliteConnection;

		public DogRepository (string dbPath)
		{
			sqliteConnection = new SQLiteConnection (dbPath);
			sqliteConnection.CreateTable<Dog> ();

		}

		public void AddNewDog(string name, string furColor)
		{
			sqliteConnection.Insert(new Dog
			{
				Name = name,
				FurColor = furColor,
				//add a default dog image for entries via the text only field
				DogPictureSource = "https://s-media-cache-ak0.pinimg.com/736x/4b/c2/ac/4bc2acd1af5130a668a4c391805f3f29--teacup-poodle-puppies-teacup-poodles.jpg"
			});

		}

		public void DeleteDog(Dog dog)
		{
           sqliteConnection.Delete(dog);

		}

		public void AddNewDogPhotoURL (string name, string furColor, string dogURL)
		{
			sqliteConnection.Insert (new Dog { Name = name, FurColor = furColor, DogPictureURL = dogURL });
		}

		public void AddNewDogPhotoFile (string name, string furColor, string dogFile)
		{
			sqliteConnection.Insert (new Dog { Name = name, FurColor = furColor, DogPictureFile = dogFile });
		}

		public void AddNewDogPhotoSource(string name, string furColor, string dogSource)
		{
            sqliteConnection.Insert(new Dog { Name = name, FurColor = furColor, DogPictureSource = dogSource });
		}


		public List<Dog> GetAllDogs ()
		{
			return sqliteConnection.Table<Dog> ().ToList ();
		}

		public Dog GetFirstDog ()
		{
			return sqliteConnection.Table<Dog> ().FirstOrDefault ();
		}

		public Dog GetLastDog ()
		{
			return sqliteConnection.Table<Dog> ().LastOrDefault ();
		}
	}
}
