import { an } from "@fullcalendar/core/internal-common";

export class Curso{
    curso_Id !: Number;
    curso_Descripcion  !: String;
    curso_DuracionHoras  !: Number;
    curso_Imagen  !: String;
    cate_Id  !: Number;
    categoria  !: String;
    curso_UsuarioCreacion !: Number;
    curso_FechaCreacion !: String;
    curso_UsuarioModificacion !: Number;
    curso_FechaModificacion !: String;
    creacion !: String;
    modificacion !: String;
    empre_Id !: String;
}



export class CursoEnviar{
    Curso_Id !: String;
    txtCurso  !: String;
    txtxEmpresa  !: String;
    txtxHoras  !: String;
    txtImagen  !: String;
    Curso_UsuarioCreacion !: String;
    Curso_FechaCreacion !: String;
    Curso_UsuarioModificacion !: String;
    Curso_FechaModificacion !: String;
    creacion !: String;
    modificacion !: String;
    contenidosSeleccionados: any;

}


export class dropCurso{
    value?:String;
    text?:String;
}

export class Fill {
    curso_Id: string;
    cont_Id: string;
    role_Rol: string;
    curso_Descripcion  !: String;
    curso_DuracionHoras  !: String;
    curso_Imagen  !: String;
    cate_Id  !: String;
    curso_UsuarioCreacion !: String;
    curso_FechaCreacion !: String;
    curso_UsuarioModificacion !: Number;
    curso_FechaModificacion !: String;
    creacion !: String;
    modificacion !: String;
}


export class ContenidoPorCursos {
    conPc_Id!:String;
    cont_Id!:String;
    cont_Descripcion?:String;
    cont_DuracionHoras !: String;
    curso_Id!:String;
    curso_Descripcion?:String;
    curso_DuracionHoras!:String;
    curso_Imagen!:String;
    cate_Descripcion!:String;
    conPc_UsuarioCreacion!:number;
    conPc_FechaCreacion!:String;
    conPc_UsuarioModificacion?:number;
    conPc_FechaModificacion?:String;
    creacion!: String;
    modificacion!:String;
    cate_Id! : String;
}