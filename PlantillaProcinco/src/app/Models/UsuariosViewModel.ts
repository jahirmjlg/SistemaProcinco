export class Usuario {
    usua_Id !: Number;
    usua_Usuario  !: String;
    usua_Contraseña  !: String;
    usua_EsAdmin  !: String;
    role_Id  !: String;
    usua_UsuarioCreacion  !: String;
    usua_FechaCreacion  !: String;
    usua_UsuarioModificacion !: Number;
    usua_FechaModificacion !: Number;
    usua_Estado !: String;
    empl_Id !: Number;
    usua_Admin1 !: String;
    usua_VerificarCorreo !: String;
    role_Descripcion !: String;
    correo !: String;
    empl_Nombre !: String;
    usuarioCreacion !: String;
    usuarioModificacion !: String;

    role_Finalizar:Boolean;
    role_Imprimir:Boolean;
}
