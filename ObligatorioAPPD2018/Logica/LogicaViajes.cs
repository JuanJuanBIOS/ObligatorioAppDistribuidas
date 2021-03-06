﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Logica.Interfaces;
using Persistencia.Interfaces;
using Persistencia;

namespace Logica
{
    internal class LogicaViajes : ILogicaViajes
    {
        //Singleton
        private static LogicaViajes _instancia = null;
        private LogicaViajes() { }

        public static LogicaViajes GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaViajes();
            }

            return _instancia;
        }


        //Operaciones
        public Viajes Buscar_Viaje(int pCodViaje)
        {
            Viajes unViaje = null;

            IPersistenciaNacionales FNacionales = FabricaPersistencia.getPersistenciaNacionales();

            unViaje = FNacionales.Buscar_Viaje(pCodViaje);

            if (unViaje == null)
            {
                IPersistenciaInternacionales FInternacionales = FabricaPersistencia.getPersistenciaInternacionales();
                unViaje = FInternacionales.Buscar_Viaje(pCodViaje);
            }

            return unViaje;
        }

        public void Alta_Viaje(Viajes unViaje)
        {
            if (unViaje is Internacionales)
            {
                IPersistenciaInternacionales FInternacional = FabricaPersistencia.getPersistenciaInternacionales();

                FInternacional.Alta_Internacional((Internacionales)unViaje);
            }

            else
            {
                IPersistenciaNacionales FNacional = FabricaPersistencia.getPersistenciaNacionales();

                FNacional.Alta_Nacional((Nacionales)unViaje);
            }
        }

        public void Modificar_Viaje(Viajes unViaje)
        {
            if (unViaje is Internacionales)
            {
                IPersistenciaInternacionales FInternacional = FabricaPersistencia.getPersistenciaInternacionales();

                FInternacional.Modificar_Internacional((Internacionales)unViaje);
            }

            else
            {
                IPersistenciaNacionales FNacional = FabricaPersistencia.getPersistenciaNacionales();

                FNacional.Modificar_Nacional((Nacionales)unViaje);
            }
        }

        public void Eliminar_Viaje(Viajes unViaje)
        {
            if (unViaje is Internacionales)
            {
                IPersistenciaInternacionales FInternacional = FabricaPersistencia.getPersistenciaInternacionales();

                FInternacional.Eliminar_Internacional((Internacionales)unViaje);
            }

            else
            {
                IPersistenciaNacionales FNacional = FabricaPersistencia.getPersistenciaNacionales();

                FNacional.Eliminar_Nacional((Nacionales)unViaje);
            }
        }

        public List<Viajes> Listar_Viajes()
        {
            List<Viajes> _Lista = new List<Viajes>();

            IPersistenciaNacionales Viajes_Nacionales = FabricaPersistencia.getPersistenciaNacionales();
            _Lista.AddRange(Viajes_Nacionales.Listar_Viajes_Nac());

            IPersistenciaInternacionales Viajes_Internacionales = FabricaPersistencia.getPersistenciaInternacionales();
            _Lista.AddRange(Viajes_Internacionales.Listar_Viajes_Int());

            return _Lista;
        }

        public List<Viajes> Listar_Todos_Viajes()
        {
            List<Viajes> _Lista = new List<Viajes>();

            IPersistenciaNacionales Viajes_Nacionales = FabricaPersistencia.getPersistenciaNacionales();
            _Lista.AddRange(Viajes_Nacionales.Listar_Todos_Viajes_Nac());

            IPersistenciaInternacionales Viajes_Internacionales = FabricaPersistencia.getPersistenciaInternacionales();
            _Lista.AddRange(Viajes_Internacionales.Listar_Todos_Viajes_Int());

            return _Lista;
        }

    }
}
