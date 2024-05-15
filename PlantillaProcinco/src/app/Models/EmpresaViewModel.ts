export class Empresa {
    empre_Id !: number;
    empre_Descripcion  !: string;
    empre_Direccion  !: string;
    ciud_Id  !: number;
    empre_UsuarioCreacion !: number;
    empre_FechaCreacion !: string;
    empre_UsuarioModificacion !: number | null;
    empre_FechaModificacion !: string | null;
    empre_Estado !: boolean | null;
    UsuarioCreacion !: string | null;
    UsuarioModificacion !: string | null;
    ciud_Descripcion !: string | null;
    esta_Id!: String;

}

export class dropEmpresas {
    empre_Id !: number;
    empre_Descripcion  !: string;
}
