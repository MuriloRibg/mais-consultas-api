using mais_consultas_api.Data;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mais_consultas_api.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AppDbContext _context;

        public ServiceService(AppDbContext context)
        {
            _context = context;
        }

        public Service Add(decimal price, string name)
        {
            Service newService = new Service
            {
                Price = price,
                Name = name
            };

            _context.Services.Add(newService);
            _context.SaveChanges();

            return newService;
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public Service Get(int id)
        {
            return _context.Services.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Service serviceToRemove = _context.Services.FirstOrDefault(y => y.Id == id);
            if (serviceToRemove != null)
            {
                _context.Services.Remove(serviceToRemove);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Service not found");
            }
        }

        public Service Update(int id, decimal price, string name)
        {
            Service serviceToUpdate = _context.Services.FirstOrDefault(y => y.Id == id);
            if (serviceToUpdate != null)
            {
                serviceToUpdate.Price = price;
                serviceToUpdate.Name = name;

                _context.SaveChanges();

                return serviceToUpdate;
            }
            else
            {
                throw new Exception("Service not found");
            }
        }
    }
}