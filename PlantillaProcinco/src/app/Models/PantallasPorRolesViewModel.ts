
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


export class PantallasPorRolesView {
    paPr_Id !: Number;
    pant_Id !: Number;
    paPr_UsuarioCreacion !: Number;
    paPr_FechaCreacion !: String;
    paPr_UsuarioModificacion !: Number;
    paPr_FechaModificacion !: String;
    paPr_Estado !: boolean;
    creacion !: String;
    modificacion !: String;
}
