using Microsoft.EntityFrameworkCore;
using RentACar_DataAccessLayer.Context;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_DataAccessLayer.Repository
{
    public class ReservationRepository
    {
         public List<Reservation> GetAllReservations(params string[] includeList)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                IQueryable<Reservation> dbSet = cnt.Reservations;

                if (includeList != null && includeList.Length > 0)
                {
                    for (int i = 0; i < includeList.Length; i++)
                    {
                        dbSet = dbSet.Include(includeList[i]);
                    }
                }
                var list = dbSet.ToList();
                return list;
            }

        }
        public Reservation GetById(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var rsv = cnt.Reservations.SingleOrDefault(x => x.ReservationID == id);
                return rsv;
            }
        }
        public Reservation Update(Reservation reservation)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var rsv = cnt.Reservations.Update(reservation);
                cnt.SaveChanges();
                return rsv.Entity;
            }

        }
        public Reservation Add(Reservation reservation)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var res = cnt.Reservations.Add(reservation);
                cnt.SaveChanges();
                return res.Entity;
            }

        }

        public void AddReservation(Reservation reservation)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                cnt.Reservations.Add(reservation);
                cnt.SaveChanges();
            }
        }
        public bool IsVehicleAvailable(int vehicleId, DateTime start, DateTime end)
    {
        using (RentacarContext cnt = new RentacarContext())
        {
            var conflictingReservation = cnt.Reservations
                .Where(r => r.VehicleID == vehicleId && r.ReservationOn &&
                            ((r.ReservationStart <= start && r.ReservationFinish >= start) ||
                             (r.ReservationStart <= end && r.ReservationFinish >= end) ||
                             (r.ReservationStart >= start && r.ReservationFinish <= end)))
                .FirstOrDefault();
            return conflictingReservation == null;
        }
    }
    }
}
