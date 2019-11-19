using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Aircraft.Data.Context;
using Microsoft.Security.Application;

namespace Aircraft.Service
{
    public class Service1 : IService1
    {
        public int Persist(int Id, string Model, string SerialNumber)
        {
            //Make sure we're dealing with a bird that acutally exists.
            if (Model != "Falcon 7X" && Model != "Falcon 8X" && Model != "Falcon 2000")
            {
                return -1;
            }

            using (Context db = new Context())
            {
                //Grab the aircraft from the database. Also have a conditional to make sure that a duplicate aircraft is not entered (model and serial combo should be unique).
                Data.Entity.Aircraft Aircraft = db.Aircrafts.FirstOrDefault(x => x.Id == Id || (x.Model == Model && x.SerialNumber == SerialNumber));
                
                if (Aircraft == null)
                {
                    //This isn't the best way to generate a primary key as it gets slower over time. But it works for this example.
                    //Ideally we would use a Sequence along with a trigger to auto-generate the keys.
                    int NextID = 1;
                    if (db.Aircrafts.Count() > 0)
                    {
                        NextID = db.Aircrafts.Select(x => x.Id).Max() + 1;
                    }

                    //Create the bird.
                    Aircraft = new Data.Entity.Aircraft();
                    Aircraft.Id = NextID;
                    db.Aircrafts.Add(Aircraft);
                }
        
                Aircraft.Model = Encoder.HtmlEncode(Model);
                Aircraft.SerialNumber = Encoder.HtmlEncode(SerialNumber?.PadLeft(3, '0'));

                if (Aircraft.Model != null && Aircraft.Model.Length > 256)
                {
                    Aircraft.Model = Aircraft.Model.Substring(0, 256);
                }

                if (Aircraft.SerialNumber != null && Aircraft.SerialNumber.Length > 3)
                {
                    Aircraft.SerialNumber = Aircraft.SerialNumber.Substring(0, 3);
                }

                db.SaveChanges();
                return Aircraft.Id;
            }
        }

        public bool Remove(int Id)
        {
            using (Context db = new Context())
            {
                var Aircraft = db.Aircrafts.FirstOrDefault(x => x.Id == Id);

                if (Aircraft != null)
                {
                    db.Aircrafts.Remove(Aircraft);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<AircraftView> Retrieve()
        {
            using (Context db = new Context())
            {
                return db.Aircrafts
                    .AsNoTracking()
                    .Select(x => new AircraftView
                    {
                        ID = x.Id,
                        Model = x.Model,
                        SerialNumber = x.SerialNumber
                    })
                    .ToList();
            }
        }
    }
}
