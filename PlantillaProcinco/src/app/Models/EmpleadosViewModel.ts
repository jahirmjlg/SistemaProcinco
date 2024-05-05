export class Empleado {
    empl_Id !: Number;
    empl_DNI  !: String;
    carg_Id !: Number;
    empl_Nombre !: String;
    empl_Apellido !: String;
    empl_Correo !: String;
    empl_FechaNacimiento !: String;
    empl_Sexo !: String;
    sexo !: String;
    estc_Id !: Number;
    estadoCivil !: String;
    empl_Direccion !: String;
    ciud_id !: String;
    ciudades !: String;
    empl_UsuarioCreacion !: Number;
    empl_FechaCreacion !: String;
    empl_UsuarioModificacion !: Number;
    empl_FechaModificacion !: String;
    empl_SalarioHora !: Number;
    usuarioCreacion!: String;
    usuarioModificacion!: String;
}

export class dropEmpleados{
    value?:String;
    text?:String;
}
