using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloAquisicao;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloRequisicao;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ControleDeMedicamentos
{
    internal class RepositorioMae <T>
    {
        private List<T> listaRegistros = new List<T>();
        private int IdRegistro;

        public void Inserir(T item)
        {
            listaRegistros.Add(item);
        }

        public List<T> RetornaDados()
        {
            return listaRegistros;
        }

        public virtual void Edita(RepositorioMae<T> repositorio)
        {
            IdRegistro = repositorio.IdRegistro;
        }

        public void EncontraPorId(int EncontraId, List<RepositorioMae<T>> lista)
        {
            foreach (var item in lista)
            {
                if (EncontraId == item.IdRegistro)
                {

                }
            }
            
        }
    }
}
