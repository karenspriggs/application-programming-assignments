using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseDemo.Services
{
    public class CharacterService
    {
        private PROG455FA23Entities db = new PROG455FA23Entities();

        /// <summary>
        /// Used on the index page, gets a list of all the characters in the database
        /// </summary>
        /// <returns></returns>
        public List<Character> ReturnCharacterList()
        {
            return db.Characters.ToList();
        }

        /// <summary>
        /// Used with all the GET methods in the character controller
        /// Returns the instance of character in the database with the same ID
        /// </summary>
        /// <param name="ID">ID to search for</param>
        /// <returns></returns>
        public Character FindCharacterWithID(int? ID)
        {
            Character character = db.Characters.Find(ID);
            return character;
        }

        public void CheckMapList(Character character)
        {
            if (character.Maps == null)
            {
                character.Maps = new List<Map>();
            }
        }

        /// <summary>
        /// Adds a character to the database
        /// </summary>
        /// <param name="character">Character to add</param>
        public void CreateCharacter(Character character)
        {
            db.Characters.Add(character);
            db.SaveChanges();
        }

        /// <summary>
        /// Edits a character in the database
        /// </summary>
        /// <param name="character"></param>
        public void EditCharacter(Character character)
        {
            db.Entry(character).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Deletes the character in the database with the inputted ID
        /// </summary>
        /// <param name="ID">ID to delete</param>
        public void DeleteCharacter(int ID)
        {
            Character character = FindCharacterWithID(ID);
            db.Characters.Remove(character);
            db.SaveChanges();
        }

        /// <summary>
        /// Disposes of unmanaged resources in the character database
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}