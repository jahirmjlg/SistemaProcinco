export class Role {
    role_Id !: Number;
    role_Descripcion  !: String;
    role_Finalizar:Boolean;
    role_Imprimir:Boolean;

    role_UsuarioCreacion !: Number;
    role_FechaCreacion !: String;
    role_UsuarioModificacion !: Number;
    role_FechaModificacion !: String;
    creacion !: String;
    modificacion !: String;

    pant_Descripcion  !: String;
    pant_Id  !: Number;

}

export class dropRoles {
    value?:String;
    text?:String;
  }

 export interface RoleWithScreens {
    screens: [{ pant_Id: number, pant_Descripcion: string }];

    role_Descripcion: Role;
    role_Finalizar:Role;
    role_Imprimir:Role;
}
