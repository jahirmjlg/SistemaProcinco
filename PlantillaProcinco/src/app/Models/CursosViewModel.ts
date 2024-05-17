import { an } from "@fullcalendar/core/internal-common";
   
   export class Curso {
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
}

export class dropCursos{
    curso_Id !: Number;
    curso_Descripcion  !: String;
}





// treeviewwwwwwwwwwwwwwwwwwwwwwwwwwww



export class Cursoo{
    curso_Id !: Number;
    curso_Descripcion  !: String;
    curso_DuracionHoras  !: String;
    curso_Imagen  !: String;
    cate_Id  !: String;
    empre_Id  !: String;
    categoria  !: String;
}

export class CursoEnviar {
    Curso_Id?:String;
    txtCurso: string;
    txtxEmpresa: string;
    txtxHoras: string;
    txtImagen: string;
    txtCategoria: string;
    contenidosSeleccionados: any;
}
export class dropCurso{
    value?:String;
    text?:String;
}

export class Fill{
    curso_Id: string;
    cont_Id: string;
    curso_Descripcion  !: String;
    curso_DuracionHoras  !: String;
    curso_Imagen  !: String;
    cate_Id  !: String;
    empre_Id  !: String;
    categoria  !: String;
    usuarioCreacion: string;
    usuarioModificacion: string;
    fechaCreacion : string;
    fechaModificacion : string;
}