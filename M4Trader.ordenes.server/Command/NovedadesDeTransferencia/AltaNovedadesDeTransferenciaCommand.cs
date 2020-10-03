using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace M4Trader.ordenes.server
{
    [DataContract(Name = "AltaNovedadesDeTransferencia")]
    public class AltaNovedadesDeTransferenciaCommand : ABMContextCommand
    {
        public override void Validate()
        {

            #region Requerido
            ValidateString(CodigoUsuario, "CodigoUsuario", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateDateTime(Fecha, "Fecha", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(CBUOrigen, "CBUOrigen", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(CBUDestino, "CBUDestino", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(BancoReceptor, "BancoReceptor", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateByte(IdMoneda, "IdMoneda", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);

            if (CachingManager.Instance.GetPersonaByCBU(CBUOrigen) == null || CachingManager.Instance.GetPersonaByCBU(CBUDestino) == null)
            {
                keyArray = new KeyArray();
                keyArray.Codigo = "CBUInvalido";
                keyArray.Parametros.Add("CBUORIGEN");
                keyArray.Parametros.Add("El CBU Ingresado no corresponde a un usr valido, por favor verifique o contactese con un administrador");
                fe.DataValidations.Add(keyArray);
                valida = false;
            }

            if (!valida)
            {
                throw fe;
            }

            #endregion
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            List<NovedadTransferenciaEntity> l = new List<NovedadTransferenciaEntity>();
            NovedadTransferenciaEntity novedadTransferencia = new NovedadTransferenciaEntity();

            novedadTransferencia.CodigoUsuario = CodigoUsuario;
            novedadTransferencia.Fecha = Fecha;
            novedadTransferencia.CBUOrigen = CBUOrigen;
            novedadTransferencia.CBUDestino = CBUDestino;
            novedadTransferencia.BancoReceptor = BancoReceptor;
            novedadTransferencia.IdMoneda = IdMoneda;
            novedadTransferencia.Importe = Importe;
            if(!string.IsNullOrEmpty(Comprobante))
                novedadTransferencia.Comprobante = Encoding.ASCII.GetBytes(Comprobante);
            novedadTransferencia.Comentarios = Comentarios;
            novedadTransferencia.IdPersona = CachingManager.Instance.GetPersonaByCBU(CBUOrigen).IdParty;
            novedadTransferencia.IdPersonaDestino = CachingManager.Instance.GetPersonaByCBU(CBUDestino).IdParty;
            novedadTransferencia.EsDepositoEnAgencia = EsDepositoEnAgencia;

            l.Add(novedadTransferencia);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(ProcesamientoGenerica(AltaNovedadesDeTransferencia, l));
        }

        private string AltaNovedadesDeTransferencia(NovedadTransferenciaEntity novedadTransferencia)
        {
            return NovedadDeTransferenciaHelper.AltaNovedadDeTransferenciaHelper(novedadTransferencia);
        }



        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.NovedadesDeTransferencia;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.ALTA;
            }
        }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        [DataMember]
        public string CodigoUsuario { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string CBUOrigen { get; set; }
        [DataMember]
        public string CBUDestino { get; set; }
        [DataMember]
        public string BancoReceptor { get; set; }
        [DataMember]
        public byte IdMoneda { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public string Comentarios { get; set; }
        [DataMember]
        public string Comprobante { get; set; }
        [DataMember]
        public bool EsDepositoEnAgencia { get; set; }

    }


}