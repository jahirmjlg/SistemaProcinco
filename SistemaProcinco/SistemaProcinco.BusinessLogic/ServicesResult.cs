using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SistemaProcinco.BunisessLogic
{
    public class ServicesResult
    {
        /// <summary>
        /// Indica el tipo de solicitud.
        /// </summary>
        [JsonIgnore]
        public ServicesResultType Type { get; set; }

        /// <summary>
        /// El codigo de respuesta de la solicitud (utilizado en el response JSON del API).
        /// </summary>
        public int Code => (int)Type;

        /// <summary>
        /// Indica si la solicitud fue o no exitosa.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// El mensaje retornado por la capa de negocios.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// El objeto retornado por la capa de negocios.
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Resultado de servicio cuando la operacion se ha realizado exitosamente (200).
        /// </summary>
        /// <param name="data">El objeto de respuesta que se pasa a la siguiente capa del sistema.</param>
        /// <returns></returns>
        public ServicesResult Ok(object data = null)
        {
            Success = true;
            Data = data;
            return SetMessage("Operación completada exitosamente.", ServicesResultType.Success);
        }

        /// <summary>
        /// Resultado de servicio cuando la operacion se ha realizado exitosamente (200).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="data">El objeto de respuesta que se pasa a la siguiente capa del sistema.</param>
        /// <returns></returns>
        public ServicesResult Ok(string message, object data = null)
        {
            Success = true;
            Data = data;
            return SetMessage(message, ServicesResultType.Success);
        }


        //public ServicesResult SetMessage(string message, ServicesResultType ServicesResultType)
        //{
        //    Message = message;
        //    Type = ServicesResultType;
        //    return this;
        //}

        /// <summary>
        /// Resultado de servicio con un mensaje informativo (100).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult Info(string message, bool success = true)
        {
            Success = success;
            return SetMessage(message, ServicesResultType.Info);
        }

        /// <summary>
        /// Resultado de servicio cuando ocurre una advertencia (202).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult Warning(string message, bool success = true)
        {
            Success = success;
            return SetMessage(message, ServicesResultType.Warning);
        }

        /// <summary>
        /// Resultado de servicio cuando ocurre un error (500).
        /// </summary>
        /// <returns></returns>
        public ServicesResult Error()
        {
            return Error("Se ha producido un error al procesar la solicitud. Si el problema persiste, comuníquese con el administrador del sistema.");
        }

        public ServicesResult Error(object data = null)
        {
            Success = false;
            Data = data;
            return SetMessage("Error al realizar la operacion.", ServicesResultType.Error);
        }

        public ServicesResult Error(object data = null, string message = "Error al realizar la operacion.")
        {
            Success = false;
            Data = data;
            return SetMessage(message, ServicesResultType.Error);
        }

        /// <summary>
        /// Resultado de servicio cuando ocurre un error en la operacion (500).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <returns></returns>
        public ServicesResult Error(string message)
        {
            Success = false;
            return SetMessage(message, ServicesResultType.Error);
        }

        /// <summary>
        /// Resultado de servicio cuando no existe el objecto o recurso (404).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult NotFound(string message = "Objeto no encontrado.", bool success = false)
        {
            Success = success;
            return SetMessage(message, ServicesResultType.NotFound);
        }

        /// <summary>
        /// Resultado de servicio cuando un objeto o recurso no es aceptado (406).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="data">Los datos a pasar en la respuesta.</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult NotAcceptable(string message = "Inaceptable.", dynamic data = null, bool success = false)
        {
            Success = success;
            Data = data;
            return SetMessage(message, ServicesResultType.NotAcceptable);
        }

        /// <summary>
        /// Resultado de servicio cuando existe un conflicto, por ejemplo objecto repetido (409).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="data">Los datos a pasar en la respuesta.</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult Conflict(string message = "Se ha detectado un conflicto con el objeto.", dynamic data = null, bool success = false)
        {
            Success = success;
            Data = data;
            return SetMessage(message, ServicesResultType.Conflict);
        }

        /// <summary>
        /// Resultado de servicio cuando la solicitud no esta autorizada (401).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult Unauthorized(string message = "Acceso no autorizado al objeto.", bool success = false)
        {
            Success = success;
            return SetMessage(message, ServicesResultType.Unauthorized);
        }

        /// <summary>
        /// Resultado de servicio cuando la solicitud es denegada (403).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult Forbidden(string message = "Prohibido el acceso al objeto.", bool success = false)
        {
            Success = success;
            return SetMessage(message, ServicesResultType.Forbidden);
        }

        /// <summary>
        /// Resultado de servicio cuando la solicitud se realiza en un formato incorrecto (400).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult BadRequest(string message = "Bad request.", bool success = false)
        {
            Success = success;
            return SetMessage(message, ServicesResultType.BadRequest);
        }

        /// <summary>
        /// Resultado de servicio cuando un objeto o recurso esta deshabilidato (410).
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="data">Los datos a pasar en la respuesta..</param>
        /// <param name="success">Si el resultado del servicio se debe marcar como exitoso o no.</param>
        /// <returns></returns>
        public ServicesResult Disabled(string message = "Disabled resource.", dynamic data = null, bool success = false)
        {
            Success = success;
            Data = data;
            return SetMessage(message, ServicesResultType.Disabled);
        }

        /// <summary>
        /// Resultado de servicio con mensaje y tipo personalizado.
        /// </summary>
        /// <param name="message">Mensaje personalizado que se pasa a la siguiente capa del sistema.</param>
        /// <param name="ServicesResultType">El tipo de resultado a retornar.</param>
        /// <returns></returns>
        public ServicesResult SetMessage(string message, ServicesResultType ServicesResultType)
        {
            Message = message;
            Type = ServicesResultType;
            return this;
        }

        public ServicesResult()
        {
            Success = false;
            Type = ServicesResultType.Error;
        }
    }
}
