namespace ContabilidadValesCajaChicaApi._Commons.MensajesGlobales
{
    public static class MensajesGlobales
    {
        #region General
        /// <summary>
        ///  Validación:
        ///  La data recibida es null.
        /// </summary>
        public static string Data_Null =>
            "Ninguna data fue enviada.";
        /// <summary>
        ///  Validación:
        ///  La data recibida es null.
        /// </summary>
        public static string Data_No_Encontrada =>
            "No se encontro ninguna data.";
        /// <summary>
        ///  Validación:
        ///  La data recibida es null.
        /// </summary>
        public static string Fecha_No_Valida =>
            "La fecha ingresada no es valida.";
        /// <summary>
        ///  Validación:
        ///  La data recibida es null.
        /// </summary>
        public static string Fecha_No_Ingresada =>
            "No se ingreso una fecha.";
        /// <summary>
        ///  Afirmación:
        ///  Éxito.
        /// </summary>
        public static string Exito =>
            "Éxito.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Nombre_Muy_Extenso =>
            "El Nombre ingresado supera el limite de caracteres.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Nombre_Ya_Existe =>
            "El nombre ingresado ya existe.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Nombre_No_Ingresado =>
            "No se ingreso ningun nombre.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Estado_Igual =>
            "No se pude cambiar el estado, ya cuenta con el estado ingresado.";
        #endregion
        #region Login
        /// <summary>
        ///  Validación:
        ///  La data recibida no es valida.
        /// </summary>
        public static string Credenciales_Incorrectas =>
            "Credenciales ingresadas son incorrectas.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no es valida.
        /// </summary>
        public static string Usuario_Inactivo =>
            "El usuario ingresado no esta activo.";
        #endregion
        #region SalidaInventario
        /// <summary>
        ///  Validación:
        ///  El inventario no esta disponible.
        /// </summary>
        public static string No_Hay_Inventario =>
            "No hay suficiente inventario para la cantidad requerida.";
        /// <summary>
        ///  Validación:
        ///  El costo no es valido.
        /// </summary>
        public static string Costo_Total_No_Valido =>
            "El costo total de la salida supera los L. 5000 No se puede realizar la salida.";
        /// <summary>
        ///  Validación:
        ///  El costo no es valido.
        /// </summary>
        public static string Costo_Total_Cero =>
            "El costo total de la salida no es valido.";
        /// <summary>
        ///  Validación:
        ///  La cantidad no valida.
        /// </summary>
        public static string Cantidad_Producto_No_Valida =>
            "La cantidad de producto no es valida.";
        /// <summary>
        ///  Validación:
        ///  La salida no existe.
        /// </summary>
        public static string Salida_No_Existe =>
            "La salida no existe o no es valido.";
        /// <summary>
        ///  Validación:
        ///  No se pudo agregar salida.
        /// </summary>
        public static string Salida_No_Procesada =>
            "La salida no se ha podido realizar.";
        /// <summary>
        ///  Validación:
        ///  Salida recepcionada.
        /// </summary>
        public static string Salida_Recepcionada =>
            "La salida ya ha sido recepcioanda.";
        #endregion
        #region Sucursales
        /// <summary>
        ///  Validación:
        ///  La sucursal no existe.
        /// </summary>
        public static string Sucursal_No_Existe =>
            "La sucursal seleccionada no existe.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Sucursal_Inactiva_Agregada =>
            "La sucursal no puede estar inactiva al agregarse.";
        #endregion
        #region Empleados
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Direccion_Muy_Extensa =>
            "La direccion ingresada supera el limite de caracteres.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Direccion_No_Ingresa =>
            "No se ingreso ninguna direccion";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Empleado_Inactivo_Agregado =>
            "El empleado no puede estar inactivo al agregarse.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Empleado_No_Existe =>
            "El empleado no existe.";
        #endregion
        #region Producto
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Producto_No_Existe =>
            "El producto no existe.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Producto_Inactivo_Agregado =>
            "El producto no puede estar inactivo al agregarse.";
        #endregion
        #region Lotes
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Lote_No_Existe =>
            "El lote no existe.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Inventario_No_Valido =>
            "La cantidad de inventario ingresado no es valido.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Inventario_No_Ingresado =>
            "No se ingreso una cantidad para el inventario.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Costo_No_Valido =>
            "La cantidad de costo ingresado no es valido.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Costo_No_Ingresado =>
            "No se ingreso una cantidad para el costo.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Cantidad_No_Valido =>
            "La cantidad inicial de lote ingresada no es valida.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Cantidad_No_Ingresado =>
            "No se ingreso una cantidad inicial para el lote.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Lote_Inactivo_Agregado =>
            "El lote no puede estar inactivo al agregarse.";
        #endregion
        #region Usuarios
        /// <summary>
        ///  Validación:
        ///  El usuario no existe.
        /// </summary>
        public static string Usuario_No_Existe =>
            "El usuario no existe.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Clave_Muy_Extensa =>
            "La clave ingresada supera el limite de caracteres.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Clave_No_Ingresada =>
            "No se ingreso ninguna clave.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Perfil_No_Existe =>
            "El perfil no existe.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Usuario_Inactivo_Agregado =>
            "El usuario no puede estar inactivo al agregarse.";
        /// <summary>
        ///  Validación:
        ///  La data recibida no valida.
        /// </summary>
        public static string Usuario_Ya_Existe =>
            "El usuario ingresado ya existe.";
        #endregion
    }
}
