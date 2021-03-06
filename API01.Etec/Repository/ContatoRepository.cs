﻿using API01.Etec.Interfaces.Repository;
using API01.Etec.Data;
using API01.Etec.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly API01EtecContext _context;
        public ContatoRepository(API01EtecContext context)
        {
            _context = context;
        }

        public IEnumerable<ContatoModel> GetAll()
        {
            return  _context.ContatoModel.ToList();

        }

        public ContatoModel GetOne(int id)
        {
            return _context.ContatoModel.Find(id);
        }

        public ContatoModel Update(ContatoModel contato)
        {
            _context.Entry(contato).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
                return this.GetOne(contato.Codigo);
            }
            catch (DbUpdateConcurrencyException)
            {
              
                {
                    return null;
                }
              
            }
        }

        public ContatoModel Insert(ContatoModel contato)
        {
            try
            {
                _context.ContatoModel.Add(contato);
                _context.SaveChangesAsync();
                return contato;
            }
            catch (Exception)
            {

                return null;
            }
           
        }
        public bool Delete(ContatoModel contato)       
        {
            try
            {
                _context.ContatoModel.Remove(contato);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
         
        }

        public IEnumerable<ContatoModel> GetByPartName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContatoModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public ContatoModel GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool ContactNameExist(int codigo, string name)
        {
            throw new NotImplementedException();
        }

        public bool ContactEmailExist(int codigo, string email)
        {
            throw new NotImplementedException();
        }
    }
}
