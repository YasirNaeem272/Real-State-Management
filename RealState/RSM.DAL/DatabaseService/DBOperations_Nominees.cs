using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace RSM.DAL.DatabaseService
{
    public class DBOperations_Nominees:DBOperations
    {
        private const string ownerDefaultImagePath = "~/SystemImages/NoUserImage.png";
        public bool InsertNomineeData(Nominee nominee, string imagePath = ownerDefaultImagePath)
        {
            nominee.ImagePath = imagePath;
            //ownerData.EntryTime = DateTime.Now;
            _ctx.Nominees.Add(nominee);
            int rowInserted = _ctx.SaveChanges();

            return rowInserted > 0;
        }

        public bool UpdateNomineeData(Nominee nominee, string imagePath)
        {
            nominee.ImagePath = imagePath;
            _ctx.Entry(nominee).State = EntityState.Modified;
            int rowsUpdated = _ctx.SaveChanges();

            return rowsUpdated > 0;
        }

        public List<Nominee> GetNominees()
        {
            return _ctx.Nominees.ToList();
        }

        public Nominee GetNomineeById(int id)
        {
            return _ctx.Nominees.Where(row => row.NomineeId == id).FirstOrDefault();
        }
        public List<Nominee> GetNomineeByOwnerId(int ownerId)
        {
            return _ctx.Nominees.Where(n => n.OwnerId == ownerId).ToList();
        }
    }
}