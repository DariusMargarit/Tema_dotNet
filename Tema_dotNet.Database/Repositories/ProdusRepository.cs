using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Tema_dotNet.Database.Context;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Database.Repositories
{
    public class ProdusRepository
    {
        private readonly ProducatorManagementDBContext _context;

        public ProdusRepository(ProducatorManagementDBContext context)
        {
            _context = context;
        }

        public Produs GetById(int id)
        {
            var result = _context.Produse.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Produs> GetProduse()
        {
            var result = _context.Produse.ToList();
            return result;
        }

        public void AddProdus(Produs produs)
        {
            if (_context.Produse.Any(p => p.Nume == produs.Nume))
            {
                throw new Exception($"Produs with name {produs.Nume} already exists");
            }
            _context.Produse.Add(produs);
            _context.SaveChanges();
        }

        public void EditProdus(Produs produs, Produs payload)
        {
            if (produs == null)
            {
                throw new Exception("Produs not found");
            }
            if (_context.Produse.Any(p => p.Nume == payload.Nume && p.Id != payload.Id))
            {
                throw new Exception($"Produs with name {payload.Nume} already exists");
            }
            produs.Nume = payload.Nume;
            produs.Pret = payload.Pret;
            produs.ProducatorId = payload.ProducatorId;
            _context.SaveChanges();
        }

        public void DeleteProdus(Produs produs)
        {
            if (produs == null)
            {
                throw new Exception("Produs not found");
            }
            _context.Produse.Remove(produs);
            _context.SaveChanges();
        }
    }
}
