export class Participante {
    part_Id !: Number;
    part_DNI  !: String;

    empre_Id !: Number;
    empre_Descripcion !: String;
    part_Nombre !: String;
    part_Apellido !: String;
    part_Correo !: String;
    part_FechaNacimiento !: String;
    part_Sexo !: String;
    sexo !: String;
    estc_Id !: Number;
    estadoCivil !: String;
    part_Direccion !: String;
    ciud_Id !: String;
    ciud_Descripcion !: String;
    empl_UsuarioCreacion !: Number;
    empl_FechaCreacion !: String;
    empl_UsuarioModificacion !: Number;
    empl_FechaModificacion !: String;
    usuarioCreacion!: String;
    usuarioModificacion!: String;
    esta_Id!: String;
}






export class Cursoo{
    curso_Id !: Number;
    curso_Descripcion  !: String;
    curso_DuracionHoras  !: String;
    curso_Imagen  !: String;
    cate_Id  !: String;
    empre_Id  !: String;
    categoria  !: String;
}

export class CursoImpartidoEnviar {
    Curso_Id?:String;
    txtCurso: string;
    txtxEmpresa: string;
    txtxHoras: string;
    txtImagen: string;
    txtCategoria: string;
    contenidosSeleccionados: any;
}



export class Fill{
    curso_Id: string;
    part_Id: string;
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