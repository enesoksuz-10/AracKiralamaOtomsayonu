using RentACar_DataAccessLayer.Context;
using RentACar_DataAccessLayer.Repository;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_BusinessLayer.Concreate
{
    public class ReservationBS
    {
        public List<Reservation> GetAllReservations(params string[] includeList)
        {
            var repo = new ReservationRepository();
            var listReservation = repo.GetAllReservations(includeList);
            return listReservation;
        }
        public Reservation GetById(int id)
        {
            var repo = new ReservationRepository();
            var reservations = repo.GetById(id);
            return reservations;
        }
        public Reservation Update(Reservation reservation)
        {
            var repo = new ReservationRepository();
            var reservations = repo.Update(reservation);
            return reservations;
        }
        public void AddReservation(Reservation reservation)
        {
            var repo = new ReservationRepository();
            repo.AddReservation(reservation);
        }
        public void Delete(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var rsrv = GetById(id);
                cnt.Reservations.Remove(rsrv);
                cnt.SaveChanges();

            }

        }
            public bool IsVehicleAvailable(int vehicleId, DateTime start, DateTime end)
    {
        var repo = new ReservationRepository();
        return repo.IsVehicleAvailable(vehicleId, start, end);
    }


    }
}
