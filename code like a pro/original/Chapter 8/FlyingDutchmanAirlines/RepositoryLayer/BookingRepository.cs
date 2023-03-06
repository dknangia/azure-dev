﻿using System;
using System.Threading.Tasks;
using FlyingDutchmanAirlines.DatabaseLayer;
using FlyingDutchmanAirlines.DatabaseLayer.Models;
using FlyingDutchmanAirlines.Exceptions;

namespace FlyingDutchmanAirlines.RepositoryLayer
{
    public class BookingRepository
    {
        private readonly FlyingDutchmanAirlinesContext _context;

        public BookingRepository(FlyingDutchmanAirlinesContext _context)
        {
            this._context = _context;
        }

        public async Task CreateBooking(int customerID, int flightNumber)
        {
            if (!customerID.IsPositiveInteger() || !flightNumber.IsPositiveInteger())
            {
                Console.WriteLine($"Argument Exception in CreateBooking! CustomerID = { customerID}, flightNumber = { flightNumber}");
                throw new ArgumentException("invalid arguments provided");
            }

            Booking newBooking = new Booking
            {
                CustomerId = customerID,
                FlightNumber = flightNumber
            };

            try
            {
                _context.Booking.Add(newBooking);
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception during database query: {exception.Message}");
                throw new CouldNotAddBookingToDatabaseException();
            }
        }
    }
}
