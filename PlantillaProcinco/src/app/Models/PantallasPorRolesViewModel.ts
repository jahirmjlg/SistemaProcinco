
export class PantallasView {
    pant_Id !: Number;
    pant_Descripcion  !: String;
    pant_UsuarioCreacion !: Number;
    pant_FechaCreacion !: String;
    pant_UsuarioModificacion !: Number;
    pant_FechaModificacion !: String;
    pant_Estado !: boolean;
    creacion !: String;
    modificacion !: String;
}


export class PantallaPorRol {
    paPr_Id !: Number;
    pant_Id  !: String;
    pantalla  !: String;
    role_Id  !: Number;
    rol  !: String;
    paPr_UsuarioCreacion  !: Number;
    paPr_FechaCreacion  !: String;
    paPr_UsuarioModificacion !: Number;
    paPr_FechaModificacion !: String;
    paPr_Estado !: Number;
    creacion !: String;
    modificacion !: String;
}
