using System;
using stonic_transaccion_be.model;
using stonic_transaccion_be.data;

namespace stonic_transaccion_be.logic
{
    public class TransaccionB2CLogic
    {
        private TransaccionB2CData oTransaccionB2CData;

        public TransaccionB2CLogic()
        {
            oTransaccionB2CData = new TransaccionB2CData();
        }

        public ReturnValue Registrar(TransaccionB2C item)
        {
            ReturnValue oReturn = new ReturnValue();
            try
            {
                oReturn = oTransaccionB2CData.Registrar(item);
            }
            catch (Exception ex)
            {
                oReturn.Success = false;
                oReturn.Message = "Error no controlado consulte con el administrador. " + ex;
            }
            return oReturn;
        }
    }
}