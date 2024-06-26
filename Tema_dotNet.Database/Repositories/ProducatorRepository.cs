﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Database.Repositories
{
    public class ProducatorRepository
    {
        private readonly ProducatorManagementDBContext _context;

        public ProducatorRepository(ProducatorManagementDBContext context)
        {
            _context = context;
        }

        public Producator GetById(int producatorId)
        {
            var result = _context.Producatori.FirstOrDefault(p => p.Id == producatorId);
            return result;
        }

        public List<Producator> GetProducatori()
        {
            var result = _context.Producatori.Include(p => p.Produse).ToList();
            return result;
        }

        public void Add(Producator producator)
        {
            if (_context.Producatori.Any(p => p.Nume == producator.Nume))
            {
                throw new Exception($"Producator with name {producator.Nume} already exists");
            }
            _context.Producatori.Add(producator);
            _context.SaveChanges();
        }

        public void Update(Producator producator)
        {
            if (producator == null)
            {
                throw new Exception("Producator not found");
            }
            if (_context.Producatori.Any(p => p.Nume == producator.Nume && p.Id != producator.Id))
            {
                throw new Exception($"Producator with name {producator.Nume} already exists");
            }
            _context.Producatori.Update(producator);
            _context.SaveChanges();
        }

        public void Delete(Producator producator)
        {
            if (producator == null)
            {
                throw new Exception("Producator not found");
            }
            if (producator.Produse.Any())
            {
                throw new Exception("Producator has products");
            }
            _context.Producatori.Remove(producator);
            _context.SaveChanges();
        }
    }
}
