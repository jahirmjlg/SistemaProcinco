USE [SistemaProcinco]
GO
/****** Object:  Schema [Acc]    Script Date: 8/5/2024 11:35:48 ******/
CREATE SCHEMA [Acc]
GO
/****** Object:  Schema [BaseSeguimiento]    Script Date: 8/5/2024 11:35:48 ******/
CREATE SCHEMA [BaseSeguimiento]
GO
/****** Object:  Schema [Grl]    Script Date: 8/5/2024 11:35:48 ******/
CREATE SCHEMA [Grl]
GO
/****** Object:  Schema [ManuelMJLG_SQLLogin_1]    Script Date: 8/5/2024 11:35:48 ******/
CREATE SCHEMA [ManuelMJLG_SQLLogin_1]
GO
/****** Object:  Schema [Pro]    Script Date: 8/5/2024 11:35:48 ******/
CREATE SCHEMA [Pro]
GO
/****** Object:  Table [Acc].[tbPantallas]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acc].[tbPantallas](
	[Pant_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pant_Descripcion] [varchar](60) NOT NULL,
	[Pant_UsuarioCreacion] [int] NOT NULL,
	[Pant_FechaCreacion] [datetime] NOT NULL,
	[Pant_UsuarioModificacion] [int] NULL,
	[Pant_FechaModificacion] [datetime] NULL,
	[Pant_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Pant_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Acc].[tbPantallasPorRoles]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acc].[tbPantallasPorRoles](
	[PaPr_Id] [int] IDENTITY(1,1) NOT NULL,
	[Pant_Id] [int] NOT NULL,
	[Role_Id] [int] NOT NULL,
	[PaPr_UsuarioCreacion] [int] NULL,
	[PaPr_FechaCreacion] [datetime] NULL,
	[PaPr_UsuarioModificacion] [int] NULL,
	[PaPr_FechaModificacion] [datetime] NULL,
	[PaPr_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaPr_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Acc].[tbRoles]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acc].[tbRoles](
	[Role_Id] [int] IDENTITY(1,1) NOT NULL,
	[Role_Descripcion] [varchar](30) NOT NULL,
	[Role_UsuarioCreacion] [int] NULL,
	[Role_FechaCreacion] [datetime] NULL,
	[Role_UsuarioModificacion] [int] NULL,
	[Role_FechaModificacion] [datetime] NULL,
	[Role_Estado] [bit] NULL,
 CONSTRAINT [PK__tbRoles__D80AB4BB88BBECB0] PRIMARY KEY CLUSTERED 
(
	[Role_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Acc].[tbUsuarios]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Acc].[tbUsuarios](
	[Usua_Id] [int] IDENTITY(1,1) NOT NULL,
	[Usua_Usuario] [varchar](60) NOT NULL,
	[Usua_Contraseña] [varchar](max) NOT NULL,
	[Usua_EsAdmin] [bit] NULL,
	[Role_Id] [int] NOT NULL,
	[Usua_UsuarioCreacion] [int] NULL,
	[Usua_FechaCreacion] [datetime] NOT NULL,
	[Usua_UsuarioModificacion] [int] NULL,
	[Usua_FechaModificacion] [datetime] NULL,
	[Usua_Estado] [bit] NULL,
	[Empl_Id] [int] NULL,
	[Usua_VerificarCorreo] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Usua_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Grl].[tbCiudades]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Grl].[tbCiudades](
	[Ciud_Id] [varchar](4) NOT NULL,
	[Ciud_Descripcion] [varchar](40) NOT NULL,
	[Esta_Id] [varchar](2) NOT NULL,
	[Ciud_UsuarioCreacion] [int] NOT NULL,
	[Ciud_FechaCreacion] [datetime] NOT NULL,
	[Ciud_UsuarioModificacion] [int] NULL,
	[Ciud_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ciud_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Grl].[tbEmpleados]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Grl].[tbEmpleados](
	[Empl_Id] [int] IDENTITY(1,1) NOT NULL,
	[Empl_DNI] [varchar](50) NULL,
	[Carg_Id] [int] NULL,
	[Empl_Nombre] [varchar](60) NULL,
	[Empl_Apellido] [varchar](60) NULL,
	[Empl_Correo] [varchar](60) NULL,
	[Empl_FechaNacimiento] [date] NULL,
	[Empl_Sexo] [char](1) NULL,
	[Estc_Id] [int] NULL,
	[Empl_Direccion] [varchar](60) NULL,
	[Ciud_id] [varchar](4) NULL,
	[Empl_UsuarioCreacion] [int] NULL,
	[Empl_FechaCreacion] [datetime] NULL,
	[Empl_UsuarioModificacion] [int] NULL,
	[Empl_FechaModificacion] [datetime] NULL,
	[Empl_Estado] [bit] NULL,
	[Empl_SalarioHora] [numeric](8, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Empl_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Grl].[tbEmpresas]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Grl].[tbEmpresas](
	[Empre_Id] [int] IDENTITY(1,1) NOT NULL,
	[Empre_Descripcion] [varchar](70) NULL,
	[Empre_Direccion] [varchar](max) NULL,
	[Ciud_Id] [varchar](4) NULL,
	[Empre_UsuarioCreacion] [int] NULL,
	[Empre_FechaCreacion] [datetime] NULL,
	[Empre_UsuarioModificacion] [int] NULL,
	[Empre_FechaModificacion] [datetime] NULL,
	[Empre_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Empre_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Grl].[tbEstados]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Grl].[tbEstados](
	[Esta_Id] [varchar](2) NOT NULL,
	[Esta_Descripcion] [varchar](40) NOT NULL,
	[Esta_UsuarioCreacion] [int] NOT NULL,
	[Esta_FechaCreacion] [datetime] NOT NULL,
	[Esta_UsuarioModificacion] [int] NULL,
	[Esta_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Esta_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Grl].[tbEstadosCiviles]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Grl].[tbEstadosCiviles](
	[Estc_Id] [int] IDENTITY(1,1) NOT NULL,
	[Estc_Descripcion] [varchar](30) NOT NULL,
	[Estc_UsuarioCreacion] [int] NOT NULL,
	[Estc_FechaCreacion] [datetime] NOT NULL,
	[Estc_UsuarioModificacion] [int] NULL,
	[Estc_FechaModificacion] [datetime] NULL,
	[Estc_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Estc_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Grl].[tbParticipantes]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Grl].[tbParticipantes](
	[Part_Id] [int] IDENTITY(1,1) NOT NULL,
	[Part_DNI] [varchar](50) NULL,
	[Empre_Id] [int] NULL,
	[Part_Nombre] [varchar](60) NULL,
	[Part_Apellido] [varchar](60) NULL,
	[Part_Correo] [varchar](60) NULL,
	[Part_FechaNacimiento] [date] NULL,
	[Part_Sexo] [char](1) NULL,
	[Estc_Id] [int] NULL,
	[Part_Direccion] [varchar](60) NULL,
	[Ciud_id] [varchar](4) NULL,
	[Part_UsuarioCreacion] [int] NULL,
	[Part_FechaCreacion] [datetime] NULL,
	[Part_UsuarioModificacion] [int] NULL,
	[Part_FechaModificacion] [datetime] NULL,
	[Part_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Part_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbCargos]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbCargos](
	[Carg_Id] [int] IDENTITY(1,1) NOT NULL,
	[Carg_Descripcion] [varchar](60) NOT NULL,
	[Carg_UsuarioCreacion] [int] NOT NULL,
	[Carg_FechaCreacion] [datetime] NOT NULL,
	[Carg_UsuarioModificacion] [int] NULL,
	[Carg_FechaModificacion] [datetime] NULL,
	[Carg_Estado] [bit] NULL,
 CONSTRAINT [PK_Carg_Id] PRIMARY KEY CLUSTERED 
(
	[Carg_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbCategorias]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbCategorias](
	[Cate_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cate_Descripcion] [varchar](60) NOT NULL,
	[Cate_Imagen] [varchar](max) NULL,
	[Cate_UsuarioCreacion] [int] NOT NULL,
	[Cate_FechaCreacion] [datetime] NOT NULL,
	[Cate_UsuarioModificacion] [int] NULL,
	[Cate_FechaModificacion] [datetime] NULL,
	[Cate_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cate_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbContenido]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbContenido](
	[Cont_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cont_Descripcion] [varchar](60) NOT NULL,
	[Cont_DuracionHoras] [int] NULL,
	[Cont_UsuarioCreacion] [int] NOT NULL,
	[Cont_FechaCreacion] [datetime] NOT NULL,
	[Cont_UsuarioModificacion] [int] NULL,
	[Cont_FechaModificacion] [datetime] NULL,
	[Cont_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cont_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbContenidoPorCurso]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbContenidoPorCurso](
	[ConPc_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cont_Id] [int] NULL,
	[Curso_Id] [int] NULL,
	[ConPc_UsuarioCreacion] [int] NOT NULL,
	[ConPc_FechaCreacion] [datetime] NOT NULL,
	[ConPc_UsuarioModificacion] [int] NULL,
	[ConPc_FechaModificacion] [datetime] NULL,
	[ConPc_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ConPc_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbCursos]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbCursos](
	[Curso_Id] [int] IDENTITY(1,1) NOT NULL,
	[Curso_Descripcion] [varchar](60) NOT NULL,
	[Curso_DuracionHoras] [int] NULL,
	[Curso_Imagen] [varchar](max) NULL,
	[Cate_Id] [int] NULL,
	[Curso_UsuarioCreacion] [int] NOT NULL,
	[Curso_FechaCreacion] [datetime] NOT NULL,
	[Curso_UsuarioModificacion] [int] NULL,
	[Curso_FechaModificacion] [datetime] NULL,
	[Curso_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Curso_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbCursosImpartidos]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbCursosImpartidos](
	[CurIm_Id] [int] IDENTITY(1,1) NOT NULL,
	[Curso_Id] [int] NULL,
	[Empl_Id] [int] NULL,
	[CurIm_FechaInicio] [datetime] NULL,
	[CurIm_FechaFin] [datetime] NULL,
	[CurIm_UsuarioFinalizacion] [int] NULL,
	[CurIm_Finalizar] [bit] NULL,
	[CurIm_UsuarioCreacion] [int] NOT NULL,
	[CurIm_FechaCreacion] [datetime] NOT NULL,
	[CurIm_UsuarioModificacion] [int] NULL,
	[CurIm_FechaModificacion] [datetime] NULL,
	[CurIm_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CurIm_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbInformeEmpleados]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbInformeEmpleados](
	[InfoE_Id] [int] IDENTITY(1,1) NOT NULL,
	[InfoE_Calificacion] [int] NULL,
	[Empl_Id] [int] NULL,
	[Curso_Id] [int] NULL,
	[InfoE_Observaciones] [varchar](max) NULL,
	[InfoE_UsuarioCreacion] [int] NULL,
	[InfoE_FechaCreacion] [datetime] NULL,
	[InfoE_UsuarioModificacion] [int] NULL,
	[InfoE_FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[InfoE_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbTitulos]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbTitulos](
	[Titl_Id] [int] IDENTITY(1,1) NOT NULL,
	[Titl_Descripcion] [varchar](60) NOT NULL,
	[Titl_ValorMonetario] [numeric](8, 2) NULL,
	[Titl_UsuarioCreacion] [int] NOT NULL,
	[Titl_FechaCreacion] [datetime] NOT NULL,
	[Titl_UsuarioModificacion] [int] NULL,
	[Titl_FechaModificacion] [datetime] NULL,
	[Titl_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Titl_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Pro].[tbTitulosPorEmpleado]    Script Date: 8/5/2024 11:35:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Pro].[tbTitulosPorEmpleado](
	[TitPe_Id] [int] IDENTITY(1,1) NOT NULL,
	[Titl_Id] [int] NULL,
	[Empl_Id] [int] NULL,
	[TitPe_UsuarioCreacion] [int] NOT NULL,
	[TitPe_FechaCreacion] [datetime] NOT NULL,
	[TitPe_UsuarioModificacion] [int] NULL,
	[TitPe_FechaModificacion] [datetime] NULL,
	[TitPe_Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TitPe_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Acc].[tbPantallas] ON 

INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (1, N'Roles', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (2, N'Usuarios', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (3, N'Empleados', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (4, N'Estados', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (5, N'Ciudades', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (6, N'Estados Civiles', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (7, N'Cursos Impartidos', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (8, N'Cursos', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (9, N'Contenido', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (10, N'Categorias', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (11, N'Informes de Empleados', 1, CAST(N'2024-03-16T00:26:43.053' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (12, N'Titulos', 1, CAST(N'2024-04-30T20:58:28.243' AS DateTime), 1, CAST(N'2024-04-30T20:59:02.220' AS DateTime), 1)
INSERT [Acc].[tbPantallas] ([Pant_Id], [Pant_Descripcion], [Pant_UsuarioCreacion], [Pant_FechaCreacion], [Pant_UsuarioModificacion], [Pant_FechaModificacion], [Pant_Estado]) VALUES (13, N'Cargos', 1, CAST(N'2024-04-30T20:50:00.000' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [Acc].[tbPantallas] OFF
GO
SET IDENTITY_INSERT [Acc].[tbPantallasPorRoles] ON 

INSERT [Acc].[tbPantallasPorRoles] ([PaPr_Id], [Pant_Id], [Role_Id], [PaPr_UsuarioCreacion], [PaPr_FechaCreacion], [PaPr_UsuarioModificacion], [PaPr_FechaModificacion], [PaPr_Estado]) VALUES (1, 1, 1, 1, CAST(N'2024-04-30T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallasPorRoles] ([PaPr_Id], [Pant_Id], [Role_Id], [PaPr_UsuarioCreacion], [PaPr_FechaCreacion], [PaPr_UsuarioModificacion], [PaPr_FechaModificacion], [PaPr_Estado]) VALUES (2, 3, 2, 1, CAST(N'2024-04-30T19:48:26.773' AS DateTime), 1, CAST(N'2024-04-30T19:52:10.083' AS DateTime), 1)
INSERT [Acc].[tbPantallasPorRoles] ([PaPr_Id], [Pant_Id], [Role_Id], [PaPr_UsuarioCreacion], [PaPr_FechaCreacion], [PaPr_UsuarioModificacion], [PaPr_FechaModificacion], [PaPr_Estado]) VALUES (3, 2, 1, 1, CAST(N'2024-04-30T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbPantallasPorRoles] ([PaPr_Id], [Pant_Id], [Role_Id], [PaPr_UsuarioCreacion], [PaPr_FechaCreacion], [PaPr_UsuarioModificacion], [PaPr_FechaModificacion], [PaPr_Estado]) VALUES (4, 3, 1, 1, CAST(N'2024-04-30T00:00:00.000' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [Acc].[tbPantallasPorRoles] OFF
GO
SET IDENTITY_INSERT [Acc].[tbRoles] ON 

INSERT [Acc].[tbRoles] ([Role_Id], [Role_Descripcion], [Role_UsuarioCreacion], [Role_FechaCreacion], [Role_UsuarioModificacion], [Role_FechaModificacion], [Role_Estado]) VALUES (1, N'Administrador', 1, CAST(N'2024-03-01T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbRoles] ([Role_Id], [Role_Descripcion], [Role_UsuarioCreacion], [Role_FechaCreacion], [Role_UsuarioModificacion], [Role_FechaModificacion], [Role_Estado]) VALUES (2, N'Usuario', 1, CAST(N'2023-03-01T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbRoles] ([Role_Id], [Role_Descripcion], [Role_UsuarioCreacion], [Role_FechaCreacion], [Role_UsuarioModificacion], [Role_FechaModificacion], [Role_Estado]) VALUES (3, N'a', 1, CAST(N'2024-04-30T21:28:35.547' AS DateTime), 1, CAST(N'2024-04-30T21:29:38.097' AS DateTime), 0)
INSERT [Acc].[tbRoles] ([Role_Id], [Role_Descripcion], [Role_UsuarioCreacion], [Role_FechaCreacion], [Role_UsuarioModificacion], [Role_FechaModificacion], [Role_Estado]) VALUES (4, N'Prueba', 1, CAST(N'2024-05-05T15:24:25.667' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbRoles] ([Role_Id], [Role_Descripcion], [Role_UsuarioCreacion], [Role_FechaCreacion], [Role_UsuarioModificacion], [Role_FechaModificacion], [Role_Estado]) VALUES (5, N'prueba22', 1, CAST(N'2024-05-05T15:28:25.097' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbRoles] ([Role_Id], [Role_Descripcion], [Role_UsuarioCreacion], [Role_FechaCreacion], [Role_UsuarioModificacion], [Role_FechaModificacion], [Role_Estado]) VALUES (6, N'prueba1', 1, CAST(N'2024-05-05T15:28:46.450' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbRoles] ([Role_Id], [Role_Descripcion], [Role_UsuarioCreacion], [Role_FechaCreacion], [Role_UsuarioModificacion], [Role_FechaModificacion], [Role_Estado]) VALUES (7, N'caciones', 1, CAST(N'2024-05-05T21:20:27.887' AS DateTime), NULL, NULL, 1)
INSERT [Acc].[tbRoles] ([Role_Id], [Role_Descripcion], [Role_UsuarioCreacion], [Role_FechaCreacion], [Role_UsuarioModificacion], [Role_FechaModificacion], [Role_Estado]) VALUES (8, N'Prueba2', 1, CAST(N'2024-10-10T00:00:00.000' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [Acc].[tbRoles] OFF
GO
SET IDENTITY_INSERT [Acc].[tbUsuarios] ON 

INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (1, N'Administrador', N'3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2', 1, 1, 1, CAST(N'2024-03-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-05-03T21:51:55.353' AS DateTime), 1, 1, NULL)
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (2, N'ajaa', N'3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2', 1, 1, 1, CAST(N'2024-04-30T22:26:08.040' AS DateTime), 1, CAST(N'2024-05-06T11:17:50.220' AS DateTime), 1, 17, N'468561')
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (3, N'fast', N'FB131BC57A477C8C9D068F1EE5622AC304195A77164CCC2D75D82DFE1A727BA8D674ED87F96143B2B416AACEFB555E3045C356FAA23E6D21DE72B85822E39FDD', 1, 1, 1, CAST(N'2024-10-10T00:00:00.000' AS DateTime), NULL, NULL, 1, 1, NULL)
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (4, N'caciones', N'F2D5659FEF6D5ADA2DB6E103C12FC1B57B21836D5718D855D45D4C9E12F135B98441DFD06E703A08627EB2F34AA686CD58110BE1BAE04A7C3FEE17B8738B7015', 0, 1, 1, CAST(N'2024-05-04T23:33:27.047' AS DateTime), 1, CAST(N'2024-05-07T14:42:38.073' AS DateTime), 1, 16, NULL)
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (5, N'Maradona', N'354269E76B12C62E5DA106847EAC6723FB091E5506F03E91AD48B5CDF18BFE47C47BCC708EF3F01A5CD2CF891D09A6C351DA3600ACFA87B935E5AD662777C2CB', 1, 1, 1, CAST(N'2024-05-05T00:08:21.673' AS DateTime), 1, CAST(N'2024-05-07T14:42:42.813' AS DateTime), 1, 17, NULL)
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (6, N'Maradona2', N'354269E76B12C62E5DA106847EAC6723FB091E5506F03E91AD48B5CDF18BFE47C47BCC708EF3F01A5CD2CF891D09A6C351DA3600ACFA87B935E5AD662777C2CB', 0, 1, 1, CAST(N'2024-05-05T00:09:00.793' AS DateTime), 1, CAST(N'2024-05-07T14:42:47.233' AS DateTime), 1, 16, NULL)
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (7, N'1234', N'3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2', 1, 1, 1, CAST(N'2024-05-05T00:11:12.663' AS DateTime), NULL, NULL, 1, 1017, NULL)
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (8, N'99', N'CFCFD1F0065F20812E51031BD692544218A8441D74E20053530AFA0A1633CC12904CB593CB4BF6707B4FFDEF727AE9140E052DC0C15117C684286F4ADBD9F9D6', 1, 1, 1, CAST(N'2024-05-05T00:13:19.220' AS DateTime), 1, CAST(N'2024-05-05T01:10:40.530' AS DateTime), 1, 17, NULL)
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (9, N'541', N'CFCFD1F0065F20812E51031BD692544218A8441D74E20053530AFA0A1633CC12904CB593CB4BF6707B4FFDEF727AE9140E052DC0C15117C684286F4ADBD9F9D6', NULL, 1, 1, CAST(N'2024-05-05T00:15:04.973' AS DateTime), NULL, NULL, 0, 16, NULL)
INSERT [Acc].[tbUsuarios] ([Usua_Id], [Usua_Usuario], [Usua_Contraseña], [Usua_EsAdmin], [Role_Id], [Usua_UsuarioCreacion], [Usua_FechaCreacion], [Usua_UsuarioModificacion], [Usua_FechaModificacion], [Usua_Estado], [Empl_Id], [Usua_VerificarCorreo]) VALUES (10, N'cacionero', N'1A7E03E1637B3E940FB3137A4030AB62E43963716DDCE5246DBCCEEDA05EE6F052422BD1B10B1430425CF309E677EBABE735844932BA15F85E4A2F69111ECA0B', 0, 1, 1, CAST(N'2024-05-05T00:54:23.573' AS DateTime), 1, CAST(N'2024-05-05T15:11:05.843' AS DateTime), 1, 16, NULL)
SET IDENTITY_INSERT [Acc].[tbUsuarios] OFF
GO
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'001', N'La Ceiba', N'01', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), 1, CAST(N'2024-05-06T10:26:30.593' AS DateTime))
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'002', N'Jutiapa', N'01', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'004', N'Trujillo', N'02', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'005', N'Tocoa', N'02', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'006', N'Sonaguera', N'02', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'007', N'Comayagua', N'03', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'008', N'Siguatepeque', N'03', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'009', N'La Libertad', N'03', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'010', N'Santa Rosa de Copán', N'04', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'011', N'La Entrada', N'04', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'012', N'Copán Ruinas', N'04', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'013', N'San Pedro Sula', N'05', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'014', N'Villanueva', N'05', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'015', N'Choloma', N'05', 1, CAST(N'2024-04-01T22:54:38.500' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'016', N'Adelaida', N'14', 1, CAST(N'2024-04-01T22:57:45.450' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'017', N'Mount Gambier', N'14', 1, CAST(N'2024-04-01T22:57:45.450' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'018', N'El Progreso', N'14', 1, CAST(N'2024-04-01T22:57:45.450' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'019', N'Buenos Aires', N'06', 1, CAST(N'2024-04-01T22:57:45.450' AS DateTime), NULL, NULL)
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'021', N'Mar luna', N'06', 1, CAST(N'2024-04-01T22:57:45.450' AS DateTime), 1, CAST(N'2024-04-30T13:50:17.463' AS DateTime))
INSERT [Grl].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_UsuarioCreacion], [Ciud_FechaCreacion], [Ciud_UsuarioModificacion], [Ciud_FechaModificacion]) VALUES (N'0555', N'cacion', N'05', 1, CAST(N'2024-05-07T20:49:07.730' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [Grl].[tbEmpleados] ON 

INSERT [Grl].[tbEmpleados] ([Empl_Id], [Empl_DNI], [Carg_Id], [Empl_Nombre], [Empl_Apellido], [Empl_Correo], [Empl_FechaNacimiento], [Empl_Sexo], [Estc_Id], [Empl_Direccion], [Ciud_id], [Empl_UsuarioCreacion], [Empl_FechaCreacion], [Empl_UsuarioModificacion], [Empl_FechaModificacion], [Empl_Estado], [Empl_SalarioHora]) VALUES (1, N'0501', 3, N'Juan', N'Matute', N'fernanmc15@gmail.com', CAST(N'1999-10-10' AS Date), N'M', 1, N'ave 13, Col. San Carlos', N'010', 1, CAST(N'2024-10-04T00:00:00.000' AS DateTime), 1, CAST(N'2024-05-04T18:40:38.473' AS DateTime), 1, CAST(4500.00 AS Numeric(8, 2)))
INSERT [Grl].[tbEmpleados] ([Empl_Id], [Empl_DNI], [Carg_Id], [Empl_Nombre], [Empl_Apellido], [Empl_Correo], [Empl_FechaNacimiento], [Empl_Sexo], [Estc_Id], [Empl_Direccion], [Ciud_id], [Empl_UsuarioCreacion], [Empl_FechaCreacion], [Empl_UsuarioModificacion], [Empl_FechaModificacion], [Empl_Estado], [Empl_SalarioHora]) VALUES (16, N'0501-2000', 4, N'Karolina', N'Herrera', N'kh@gmail.com', NULL, N'F', 1, N'nueva direccion', N'021', 1, CAST(N'2024-04-25T11:21:35.260' AS DateTime), NULL, NULL, 1, NULL)
INSERT [Grl].[tbEmpleados] ([Empl_Id], [Empl_DNI], [Carg_Id], [Empl_Nombre], [Empl_Apellido], [Empl_Correo], [Empl_FechaNacimiento], [Empl_Sexo], [Estc_Id], [Empl_Direccion], [Ciud_id], [Empl_UsuarioCreacion], [Empl_FechaCreacion], [Empl_UsuarioModificacion], [Empl_FechaModificacion], [Empl_Estado], [Empl_SalarioHora]) VALUES (17, N'05012004', 4, N'Manuel', N'Lara', N'jahir.lara98@gmail.com', CAST(N'2024-08-15' AS Date), N'M', 1, N'ahi mero', N'010', 1, CAST(N'2024-04-30T14:48:56.437' AS DateTime), 1, CAST(N'2024-04-30T14:56:04.687' AS DateTime), 1, NULL)
INSERT [Grl].[tbEmpleados] ([Empl_Id], [Empl_DNI], [Carg_Id], [Empl_Nombre], [Empl_Apellido], [Empl_Correo], [Empl_FechaNacimiento], [Empl_Sexo], [Estc_Id], [Empl_Direccion], [Ciud_id], [Empl_UsuarioCreacion], [Empl_FechaCreacion], [Empl_UsuarioModificacion], [Empl_FechaModificacion], [Empl_Estado], [Empl_SalarioHora]) VALUES (1017, N'05012004', 3, N'Manuel', N'Lara', N'jahir.lara98@gmail.com', CAST(N'2024-08-15' AS Date), N'M', 1, N'ahi mero', N'010', 1, CAST(N'2024-04-30T14:57:22.497' AS DateTime), NULL, NULL, 1, NULL)
INSERT [Grl].[tbEmpleados] ([Empl_Id], [Empl_DNI], [Carg_Id], [Empl_Nombre], [Empl_Apellido], [Empl_Correo], [Empl_FechaNacimiento], [Empl_Sexo], [Estc_Id], [Empl_Direccion], [Ciud_id], [Empl_UsuarioCreacion], [Empl_FechaCreacion], [Empl_UsuarioModificacion], [Empl_FechaModificacion], [Empl_Estado], [Empl_SalarioHora]) VALUES (1018, N'010101', 4, N'Prueba', N'Test', N'test@gmail.com', CAST(N'2024-05-31' AS Date), N'M', 1, N'direccion exactaaaa', N'004', 1, CAST(N'2024-05-04T16:48:58.303' AS DateTime), NULL, NULL, 0, NULL)
SET IDENTITY_INSERT [Grl].[tbEmpleados] OFF
GO
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'01', N'Atlántida', 1, CAST(N'2024-04-01T22:47:11.870' AS DateTime), 1, CAST(N'2024-05-04T11:30:55.173' AS DateTime))
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'02', N'Colón', 1, CAST(N'2024-04-01T22:47:11.870' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'03', N'Comayagua', 1, CAST(N'2024-04-01T22:47:11.870' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'04', N'Copán', 1, CAST(N'2024-04-01T22:47:11.870' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'05', N'Cortés', 1, CAST(N'2024-04-01T22:47:11.870' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'06', N'malos aires', 1, CAST(N'2024-04-01T22:47:48.100' AS DateTime), 1, CAST(N'2024-04-30T13:33:00.457' AS DateTime))
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'08', N'Santa Fe', 1, CAST(N'2024-04-01T22:47:48.100' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'09', N'Mendoza', 1, CAST(N'2024-04-01T22:47:48.100' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'10', N'Tucumán', 1, CAST(N'2024-04-01T22:47:48.100' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'11', N'Nueva Gales del Sur', 1, CAST(N'2024-04-01T22:49:24.880' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'12', N'Victoria', 1, CAST(N'2024-04-01T22:49:24.880' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'13', N'Queenon', 1, CAST(N'2024-04-01T22:49:24.880' AS DateTime), 1, CAST(N'2024-05-07T20:49:28.787' AS DateTime))
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'14', N'Australia Meridional', 1, CAST(N'2024-04-01T22:49:24.880' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'15', N'Australia Occidental', 1, CAST(N'2024-04-01T22:49:24.880' AS DateTime), NULL, NULL)
INSERT [Grl].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_UsuarioCreacion], [Esta_FechaCreacion], [Esta_UsuarioModificacion], [Esta_FechaModificacion]) VALUES (N'54', N'cacionero', 1, CAST(N'2024-05-07T20:55:11.013' AS DateTime), 1, CAST(N'2024-05-07T20:55:18.020' AS DateTime))
GO
SET IDENTITY_INSERT [Grl].[tbEstadosCiviles] ON 

INSERT [Grl].[tbEstadosCiviles] ([Estc_Id], [Estc_Descripcion], [Estc_UsuarioCreacion], [Estc_FechaCreacion], [Estc_UsuarioModificacion], [Estc_FechaModificacion], [Estc_Estado]) VALUES (1, N'Soltero', 1, CAST(N'2023-10-11T00:00:00.000' AS DateTime), 1, CAST(N'2024-04-10T17:35:12.660' AS DateTime), 1)
INSERT [Grl].[tbEstadosCiviles] ([Estc_Id], [Estc_Descripcion], [Estc_UsuarioCreacion], [Estc_FechaCreacion], [Estc_UsuarioModificacion], [Estc_FechaModificacion], [Estc_Estado]) VALUES (2, N'Casado', 1, CAST(N'2024-04-10T17:18:47.473' AS DateTime), NULL, NULL, 1)
INSERT [Grl].[tbEstadosCiviles] ([Estc_Id], [Estc_Descripcion], [Estc_UsuarioCreacion], [Estc_FechaCreacion], [Estc_UsuarioModificacion], [Estc_FechaModificacion], [Estc_Estado]) VALUES (3, N'Viudo', 1, CAST(N'2024-04-30T15:52:33.510' AS DateTime), 1, CAST(N'2024-04-30T15:53:40.633' AS DateTime), 1)
INSERT [Grl].[tbEstadosCiviles] ([Estc_Id], [Estc_Descripcion], [Estc_UsuarioCreacion], [Estc_FechaCreacion], [Estc_UsuarioModificacion], [Estc_FechaModificacion], [Estc_Estado]) VALUES (4, N'virgen', 1, CAST(N'2024-04-30T15:53:47.523' AS DateTime), NULL, NULL, 0)
INSERT [Grl].[tbEstadosCiviles] ([Estc_Id], [Estc_Descripcion], [Estc_UsuarioCreacion], [Estc_FechaCreacion], [Estc_UsuarioModificacion], [Estc_FechaModificacion], [Estc_Estado]) VALUES (5, N'Cañadl', 1, CAST(N'2024-05-04T21:59:08.843' AS DateTime), 1, CAST(N'2024-05-04T22:01:54.463' AS DateTime), 0)
SET IDENTITY_INSERT [Grl].[tbEstadosCiviles] OFF
GO
SET IDENTITY_INSERT [Pro].[tbCargos] ON 

INSERT [Pro].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_UsuarioCreacion], [Carg_FechaCreacion], [Carg_UsuarioModificacion], [Carg_FechaModificacion], [Carg_Estado]) VALUES (3, N'Logistica', 1, CAST(N'2024-05-01T11:57:12.050' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_UsuarioCreacion], [Carg_FechaCreacion], [Carg_UsuarioModificacion], [Carg_FechaModificacion], [Carg_Estado]) VALUES (4, N'Instructor', 1, CAST(N'2024-05-01T11:57:29.547' AS DateTime), 1, CAST(N'2024-05-01T11:58:35.427' AS DateTime), 1)
INSERT [Pro].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_UsuarioCreacion], [Carg_FechaCreacion], [Carg_UsuarioModificacion], [Carg_FechaModificacion], [Carg_Estado]) VALUES (6, N'Contador', 1, CAST(N'2024-05-07T02:12:09.137' AS DateTime), NULL, NULL, 0)
INSERT [Pro].[tbCargos] ([Carg_Id], [Carg_Descripcion], [Carg_UsuarioCreacion], [Carg_FechaCreacion], [Carg_UsuarioModificacion], [Carg_FechaModificacion], [Carg_Estado]) VALUES (8, N'Oficinista', 1, CAST(N'2024-05-07T20:57:24.973' AS DateTime), 1, CAST(N'2024-05-07T21:32:28.980' AS DateTime), 1)
SET IDENTITY_INSERT [Pro].[tbCargos] OFF
GO
SET IDENTITY_INSERT [Pro].[tbCategorias] ON 

INSERT [Pro].[tbCategorias] ([Cate_Id], [Cate_Descripcion], [Cate_Imagen], [Cate_UsuarioCreacion], [Cate_FechaCreacion], [Cate_UsuarioModificacion], [Cate_FechaModificacion], [Cate_Estado]) VALUES (1, N'informatica', NULL, 1, CAST(N'2024-05-01T11:51:40.890' AS DateTime), 1, CAST(N'2024-05-01T11:52:08.870' AS DateTime), 1)
INSERT [Pro].[tbCategorias] ([Cate_Id], [Cate_Descripcion], [Cate_Imagen], [Cate_UsuarioCreacion], [Cate_FechaCreacion], [Cate_UsuarioModificacion], [Cate_FechaModificacion], [Cate_Estado]) VALUES (2, N'Nuevo Curso', NULL, 1, CAST(N'2024-05-06T08:53:51.393' AS DateTime), NULL, NULL, 0)
INSERT [Pro].[tbCategorias] ([Cate_Id], [Cate_Descripcion], [Cate_Imagen], [Cate_UsuarioCreacion], [Cate_FechaCreacion], [Cate_UsuarioModificacion], [Cate_FechaModificacion], [Cate_Estado]) VALUES (3, N'Nueva Categoriaa', N'1715008288915-680149630-PROCINCO_White.png', 1, CAST(N'2024-05-06T09:12:02.490' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCategorias] ([Cate_Id], [Cate_Descripcion], [Cate_Imagen], [Cate_UsuarioCreacion], [Cate_FechaCreacion], [Cate_UsuarioModificacion], [Cate_FechaModificacion], [Cate_Estado]) VALUES (4, N'new', N'1715014551996-637676743-Captura de pantalla 2024-02-05 111627.png', 1, CAST(N'2024-05-06T10:55:57.253' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [Pro].[tbCategorias] OFF
GO
SET IDENTITY_INSERT [Pro].[tbContenido] ON 

INSERT [Pro].[tbContenido] ([Cont_Id], [Cont_Descripcion], [Cont_DuracionHoras], [Cont_UsuarioCreacion], [Cont_FechaCreacion], [Cont_UsuarioModificacion], [Cont_FechaModificacion], [Cont_Estado]) VALUES (1, N'Videos', 20, 1, CAST(N'2024-05-01T12:00:52.793' AS DateTime), 1, CAST(N'2024-05-01T12:05:09.730' AS DateTime), 1)
INSERT [Pro].[tbContenido] ([Cont_Id], [Cont_Descripcion], [Cont_DuracionHoras], [Cont_UsuarioCreacion], [Cont_FechaCreacion], [Cont_UsuarioModificacion], [Cont_FechaModificacion], [Cont_Estado]) VALUES (2, N'PbEliminado', 0, 1, CAST(N'2024-05-01T12:05:41.820' AS DateTime), NULL, NULL, 0)
INSERT [Pro].[tbContenido] ([Cont_Id], [Cont_Descripcion], [Cont_DuracionHoras], [Cont_UsuarioCreacion], [Cont_FechaCreacion], [Cont_UsuarioModificacion], [Cont_FechaModificacion], [Cont_Estado]) VALUES (3, N'cancion', 40, 1, CAST(N'2024-05-04T15:11:00.947' AS DateTime), 1, CAST(N'2024-05-04T15:41:09.957' AS DateTime), 0)
INSERT [Pro].[tbContenido] ([Cont_Id], [Cont_Descripcion], [Cont_DuracionHoras], [Cont_UsuarioCreacion], [Cont_FechaCreacion], [Cont_UsuarioModificacion], [Cont_FechaModificacion], [Cont_Estado]) VALUES (4, N'canciones', 10, 1, CAST(N'2024-05-04T15:42:28.497' AS DateTime), 1, CAST(N'2024-05-07T22:07:30.650' AS DateTime), 1)
SET IDENTITY_INSERT [Pro].[tbContenido] OFF
GO
SET IDENTITY_INSERT [Pro].[tbContenidoPorCurso] ON 

INSERT [Pro].[tbContenidoPorCurso] ([ConPc_Id], [Cont_Id], [Curso_Id], [ConPc_UsuarioCreacion], [ConPc_FechaCreacion], [ConPc_UsuarioModificacion], [ConPc_FechaModificacion], [ConPc_Estado]) VALUES (1, 1, 1, 1, CAST(N'2024-05-01T12:10:15.730' AS DateTime), 1, CAST(N'2024-05-01T12:13:28.030' AS DateTime), 1)
INSERT [Pro].[tbContenidoPorCurso] ([ConPc_Id], [Cont_Id], [Curso_Id], [ConPc_UsuarioCreacion], [ConPc_FechaCreacion], [ConPc_UsuarioModificacion], [ConPc_FechaModificacion], [ConPc_Estado]) VALUES (2, 2, 1, 1, CAST(N'2024-05-01T12:13:36.743' AS DateTime), NULL, NULL, 0)
INSERT [Pro].[tbContenidoPorCurso] ([ConPc_Id], [Cont_Id], [Curso_Id], [ConPc_UsuarioCreacion], [ConPc_FechaCreacion], [ConPc_UsuarioModificacion], [ConPc_FechaModificacion], [ConPc_Estado]) VALUES (3, 1, 5, 1, CAST(N'2024-05-08T09:48:50.870' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [Pro].[tbContenidoPorCurso] OFF
GO
SET IDENTITY_INSERT [Pro].[tbCursos] ON 

INSERT [Pro].[tbCursos] ([Curso_Id], [Curso_Descripcion], [Curso_DuracionHoras], [Curso_Imagen], [Cate_Id], [Curso_UsuarioCreacion], [Curso_FechaCreacion], [Curso_UsuarioModificacion], [Curso_FechaModificacion], [Curso_Estado]) VALUES (1, N'Algo', 60, N'NA', 1, 1, CAST(N'2024-05-01T12:07:28.527' AS DateTime), 1, CAST(N'2024-05-08T00:34:33.373' AS DateTime), 1)
INSERT [Pro].[tbCursos] ([Curso_Id], [Curso_Descripcion], [Curso_DuracionHoras], [Curso_Imagen], [Cate_Id], [Curso_UsuarioCreacion], [Curso_FechaCreacion], [Curso_UsuarioModificacion], [Curso_FechaModificacion], [Curso_Estado]) VALUES (2, N'SQL', 10, N'NA', 1, 1, CAST(N'2024-05-01T12:20:02.297' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCursos] ([Curso_Id], [Curso_Descripcion], [Curso_DuracionHoras], [Curso_Imagen], [Cate_Id], [Curso_UsuarioCreacion], [Curso_FechaCreacion], [Curso_UsuarioModificacion], [Curso_FechaModificacion], [Curso_Estado]) VALUES (3, N'Test', 13, N'1714976917364-592914896-iconoimg.png', 1, 1, CAST(N'2024-05-06T00:29:30.660' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCursos] ([Curso_Id], [Curso_Descripcion], [Curso_DuracionHoras], [Curso_Imagen], [Cate_Id], [Curso_UsuarioCreacion], [Curso_FechaCreacion], [Curso_UsuarioModificacion], [Curso_FechaModificacion], [Curso_Estado]) VALUES (4, N'prueba27', 23, N'1715112445565-825979160-angular.png', 3, 1, CAST(N'2024-05-07T14:07:27.700' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCursos] ([Curso_Id], [Curso_Descripcion], [Curso_DuracionHoras], [Curso_Imagen], [Cate_Id], [Curso_UsuarioCreacion], [Curso_FechaCreacion], [Curso_UsuarioModificacion], [Curso_FechaModificacion], [Curso_Estado]) VALUES (5, N'Angular', 60, N'1715112634416-646239610-angular.png', 1, 1, CAST(N'2024-05-07T14:10:36.283' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [Pro].[tbCursos] OFF
GO
SET IDENTITY_INSERT [Pro].[tbCursosImpartidos] ON 

INSERT [Pro].[tbCursosImpartidos] ([CurIm_Id], [Curso_Id], [Empl_Id], [CurIm_FechaInicio], [CurIm_FechaFin], [CurIm_UsuarioFinalizacion], [CurIm_Finalizar], [CurIm_UsuarioCreacion], [CurIm_FechaCreacion], [CurIm_UsuarioModificacion], [CurIm_FechaModificacion], [CurIm_Estado]) VALUES (1, 1, 1, CAST(N'2024-05-01T18:21:59.947' AS DateTime), CAST(N'2024-05-01T18:21:59.947' AS DateTime), NULL, 1, 1, CAST(N'2024-05-01T12:22:07.247' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCursosImpartidos] ([CurIm_Id], [Curso_Id], [Empl_Id], [CurIm_FechaInicio], [CurIm_FechaFin], [CurIm_UsuarioFinalizacion], [CurIm_Finalizar], [CurIm_UsuarioCreacion], [CurIm_FechaCreacion], [CurIm_UsuarioModificacion], [CurIm_FechaModificacion], [CurIm_Estado]) VALUES (4, 2, 1, CAST(N'2024-10-10T00:00:00.000' AS DateTime), CAST(N'2024-10-11T00:00:00.000' AS DateTime), NULL, 1, 1, CAST(N'2024-04-02T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCursosImpartidos] ([CurIm_Id], [Curso_Id], [Empl_Id], [CurIm_FechaInicio], [CurIm_FechaFin], [CurIm_UsuarioFinalizacion], [CurIm_Finalizar], [CurIm_UsuarioCreacion], [CurIm_FechaCreacion], [CurIm_UsuarioModificacion], [CurIm_FechaModificacion], [CurIm_Estado]) VALUES (5, 1, 16, CAST(N'2024-03-04T00:00:00.000' AS DateTime), NULL, NULL, 0, 1, CAST(N'2024-05-05T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCursosImpartidos] ([CurIm_Id], [Curso_Id], [Empl_Id], [CurIm_FechaInicio], [CurIm_FechaFin], [CurIm_UsuarioFinalizacion], [CurIm_Finalizar], [CurIm_UsuarioCreacion], [CurIm_FechaCreacion], [CurIm_UsuarioModificacion], [CurIm_FechaModificacion], [CurIm_Estado]) VALUES (6, 1, 16, CAST(N'2024-04-04T00:00:00.000' AS DateTime), CAST(N'2024-03-11T00:00:00.000' AS DateTime), NULL, 1, 1, CAST(N'2024-05-05T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCursosImpartidos] ([CurIm_Id], [Curso_Id], [Empl_Id], [CurIm_FechaInicio], [CurIm_FechaFin], [CurIm_UsuarioFinalizacion], [CurIm_Finalizar], [CurIm_UsuarioCreacion], [CurIm_FechaCreacion], [CurIm_UsuarioModificacion], [CurIm_FechaModificacion], [CurIm_Estado]) VALUES (7, 1, 1, CAST(N'2024-04-04T00:00:00.000' AS DateTime), NULL, NULL, 0, 1, CAST(N'2024-05-05T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [Pro].[tbCursosImpartidos] ([CurIm_Id], [Curso_Id], [Empl_Id], [CurIm_FechaInicio], [CurIm_FechaFin], [CurIm_UsuarioFinalizacion], [CurIm_Finalizar], [CurIm_UsuarioCreacion], [CurIm_FechaCreacion], [CurIm_UsuarioModificacion], [CurIm_FechaModificacion], [CurIm_Estado]) VALUES (9, 5, 1, CAST(N'2024-05-17T14:23:00.000' AS DateTime), CAST(N'2024-05-30T14:23:00.000' AS DateTime), NULL, 1, 1, CAST(N'2024-05-07T14:24:29.447' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [Pro].[tbCursosImpartidos] OFF
GO
SET IDENTITY_INSERT [Pro].[tbInformeEmpleados] ON 

INSERT [Pro].[tbInformeEmpleados] ([InfoE_Id], [InfoE_Calificacion], [Empl_Id], [Curso_Id], [InfoE_Observaciones], [InfoE_UsuarioCreacion], [InfoE_FechaCreacion], [InfoE_UsuarioModificacion], [InfoE_FechaModificacion]) VALUES (1, 100, 16, 1, N'nada', 1, CAST(N'2024-05-01T12:26:37.737' AS DateTime), 1, CAST(N'2024-05-01T12:28:45.667' AS DateTime))
SET IDENTITY_INSERT [Pro].[tbInformeEmpleados] OFF
GO
SET IDENTITY_INSERT [Pro].[tbTitulos] ON 

INSERT [Pro].[tbTitulos] ([Titl_Id], [Titl_Descripcion], [Titl_ValorMonetario], [Titl_UsuarioCreacion], [Titl_FechaCreacion], [Titl_UsuarioModificacion], [Titl_FechaModificacion], [Titl_Estado]) VALUES (1, N'10', CAST(0.00 AS Numeric(8, 2)), 1, CAST(N'2024-05-01T12:36:46.023' AS DateTime), 1, CAST(N'2024-05-01T12:37:09.117' AS DateTime), 1)
INSERT [Pro].[tbTitulos] ([Titl_Id], [Titl_Descripcion], [Titl_ValorMonetario], [Titl_UsuarioCreacion], [Titl_FechaCreacion], [Titl_UsuarioModificacion], [Titl_FechaModificacion], [Titl_Estado]) VALUES (2, N'Dominicana', CAST(9000.00 AS Numeric(8, 2)), 1, CAST(N'2024-05-04T17:39:51.333' AS DateTime), 1, CAST(N'2024-05-04T17:46:22.110' AS DateTime), 1)
INSERT [Pro].[tbTitulos] ([Titl_Id], [Titl_Descripcion], [Titl_ValorMonetario], [Titl_UsuarioCreacion], [Titl_FechaCreacion], [Titl_UsuarioModificacion], [Titl_FechaModificacion], [Titl_Estado]) VALUES (3, N'Ingeniero', CAST(1000.00 AS Numeric(8, 2)), 1, CAST(N'2024-05-04T17:40:54.050' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [Pro].[tbTitulos] OFF
GO
SET IDENTITY_INSERT [Pro].[tbTitulosPorEmpleado] ON 

INSERT [Pro].[tbTitulosPorEmpleado] ([TitPe_Id], [Titl_Id], [Empl_Id], [TitPe_UsuarioCreacion], [TitPe_FechaCreacion], [TitPe_UsuarioModificacion], [TitPe_FechaModificacion], [TitPe_Estado]) VALUES (1, 1, 16, 1, CAST(N'2024-05-01T12:39:53.757' AS DateTime), 1, CAST(N'2024-05-01T12:43:06.067' AS DateTime), 1)
SET IDENTITY_INSERT [Pro].[tbTitulosPorEmpleado] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tbPantallas_Pant_Descripcion]    Script Date: 8/5/2024 11:35:54 ******/
ALTER TABLE [Acc].[tbPantallas] ADD  CONSTRAINT [UK_tbPantallas_Pant_Descripcion] UNIQUE NONCLUSTERED 
(
	[Pant_Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tbRoles_Role_Descripcion]    Script Date: 8/5/2024 11:35:54 ******/
ALTER TABLE [Acc].[tbRoles] ADD  CONSTRAINT [UK_tbRoles_Role_Descripcion] UNIQUE NONCLUSTERED 
(
	[Role_Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tbUsuarios_Usua_Usuario]    Script Date: 8/5/2024 11:35:54 ******/
ALTER TABLE [Acc].[tbUsuarios] ADD  CONSTRAINT [UK_tbUsuarios_Usua_Usuario] UNIQUE NONCLUSTERED 
(
	[Usua_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tbCiudades_Ciud_Descripcion]    Script Date: 8/5/2024 11:35:54 ******/
ALTER TABLE [Grl].[tbCiudades] ADD  CONSTRAINT [UK_tbCiudades_Ciud_Descripcion] UNIQUE NONCLUSTERED 
(
	[Ciud_Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tbEstados_Esta_Descripcion]    Script Date: 8/5/2024 11:35:54 ******/
ALTER TABLE [Grl].[tbEstados] ADD  CONSTRAINT [UK_tbEstados_Esta_Descripcion] UNIQUE NONCLUSTERED 
(
	[Esta_Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tbEstadosCiviles_Estc_Descripcion]    Script Date: 8/5/2024 11:35:54 ******/
ALTER TABLE [Grl].[tbEstadosCiviles] ADD  CONSTRAINT [UK_tbEstadosCiviles_Estc_Descripcion] UNIQUE NONCLUSTERED 
(
	[Estc_Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [Acc].[tbPantallas] ADD  DEFAULT ((1)) FOR [Pant_Estado]
GO
ALTER TABLE [Acc].[tbPantallasPorRoles] ADD  DEFAULT ((1)) FOR [PaPr_Estado]
GO
ALTER TABLE [Acc].[tbRoles] ADD  CONSTRAINT [DF__tbRoles__Role_Es__48CFD27E]  DEFAULT ((1)) FOR [Role_Estado]
GO
ALTER TABLE [Acc].[tbUsuarios] ADD  DEFAULT ((1)) FOR [Usua_Estado]
GO
ALTER TABLE [Grl].[tbEmpleados] ADD  DEFAULT ((1)) FOR [Empl_Estado]
GO
ALTER TABLE [Grl].[tbEmpresas] ADD  DEFAULT ((0)) FOR [Empre_Estado]
GO
ALTER TABLE [Grl].[tbEstadosCiviles] ADD  DEFAULT ((1)) FOR [Estc_Estado]
GO
ALTER TABLE [Grl].[tbParticipantes] ADD  DEFAULT ((0)) FOR [Part_Estado]
GO
ALTER TABLE [Pro].[tbCargos] ADD  DEFAULT ((1)) FOR [Carg_Estado]
GO
ALTER TABLE [Pro].[tbCategorias] ADD  DEFAULT ((1)) FOR [Cate_Estado]
GO
ALTER TABLE [Pro].[tbContenido] ADD  DEFAULT ((1)) FOR [Cont_Estado]
GO
ALTER TABLE [Pro].[tbContenidoPorCurso] ADD  DEFAULT ((1)) FOR [ConPc_Estado]
GO
ALTER TABLE [Pro].[tbCursos] ADD  DEFAULT ((1)) FOR [Curso_Estado]
GO
ALTER TABLE [Pro].[tbCursosImpartidos] ADD  DEFAULT ((1)) FOR [CurIm_Finalizar]
GO
ALTER TABLE [Pro].[tbCursosImpartidos] ADD  DEFAULT ((1)) FOR [CurIm_Estado]
GO
ALTER TABLE [Pro].[tbTitulos] ADD  DEFAULT ((1)) FOR [Titl_Estado]
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado] ADD  DEFAULT ((1)) FOR [TitPe_Estado]
GO
ALTER TABLE [Acc].[tbPantallas]  WITH CHECK ADD  CONSTRAINT [FK_tbPantallas_tbUsuarios_UsuarioCreacion] FOREIGN KEY([Pant_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acc].[tbPantallas] CHECK CONSTRAINT [FK_tbPantallas_tbUsuarios_UsuarioCreacion]
GO
ALTER TABLE [Acc].[tbPantallas]  WITH CHECK ADD  CONSTRAINT [FK_tbPantallas_tbUsuarios_UsuarioModificacion] FOREIGN KEY([Pant_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acc].[tbPantallas] CHECK CONSTRAINT [FK_tbPantallas_tbUsuarios_UsuarioModificacion]
GO
ALTER TABLE [Acc].[tbPantallasPorRoles]  WITH CHECK ADD  CONSTRAINT [FK_tbPantallasPorRoles_tbUsuarios_UsuarioCreacion] FOREIGN KEY([PaPr_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acc].[tbPantallasPorRoles] CHECK CONSTRAINT [FK_tbPantallasPorRoles_tbUsuarios_UsuarioCreacion]
GO
ALTER TABLE [Acc].[tbPantallasPorRoles]  WITH CHECK ADD  CONSTRAINT [FK_tbPantallasPorRoles_tbUsuarios_UsuarioModificacion] FOREIGN KEY([PaPr_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acc].[tbPantallasPorRoles] CHECK CONSTRAINT [FK_tbPantallasPorRoles_tbUsuarios_UsuarioModificacion]
GO
ALTER TABLE [Acc].[tbPantallasPorRoles]  WITH CHECK ADD  CONSTRAINT [FK_tbPantallasxRol_tbPantallas_Pant_Id] FOREIGN KEY([Pant_Id])
REFERENCES [Acc].[tbPantallas] ([Pant_Id])
GO
ALTER TABLE [Acc].[tbPantallasPorRoles] CHECK CONSTRAINT [FK_tbPantallasxRol_tbPantallas_Pant_Id]
GO
ALTER TABLE [Acc].[tbPantallasPorRoles]  WITH CHECK ADD  CONSTRAINT [FK_tbPantallasxRol_tbRoles_Role_Id] FOREIGN KEY([Role_Id])
REFERENCES [Acc].[tbRoles] ([Role_Id])
GO
ALTER TABLE [Acc].[tbPantallasPorRoles] CHECK CONSTRAINT [FK_tbPantallasxRol_tbRoles_Role_Id]
GO
ALTER TABLE [Acc].[tbRoles]  WITH CHECK ADD  CONSTRAINT [FK_tbRoles_tbUsuarios_UsuarioCreacion] FOREIGN KEY([Role_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acc].[tbRoles] CHECK CONSTRAINT [FK_tbRoles_tbUsuarios_UsuarioCreacion]
GO
ALTER TABLE [Acc].[tbRoles]  WITH CHECK ADD  CONSTRAINT [FK_tbRoles_tbUsuarios_UsuarioModificacion] FOREIGN KEY([Role_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acc].[tbRoles] CHECK CONSTRAINT [FK_tbRoles_tbUsuarios_UsuarioModificacion]
GO
ALTER TABLE [Acc].[tbUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuarios_tbEmpleados_Empl_Id] FOREIGN KEY([Empl_Id])
REFERENCES [Grl].[tbEmpleados] ([Empl_Id])
GO
ALTER TABLE [Acc].[tbUsuarios] CHECK CONSTRAINT [FK_tbUsuarios_tbEmpleados_Empl_Id]
GO
ALTER TABLE [Acc].[tbUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuarios_tbRoles_Role_Id] FOREIGN KEY([Role_Id])
REFERENCES [Acc].[tbRoles] ([Role_Id])
GO
ALTER TABLE [Acc].[tbUsuarios] CHECK CONSTRAINT [FK_tbUsuarios_tbRoles_Role_Id]
GO
ALTER TABLE [Acc].[tbUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuarios_tbUsuarios_UsuarioCreacion] FOREIGN KEY([Usua_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acc].[tbUsuarios] CHECK CONSTRAINT [FK_tbUsuarios_tbUsuarios_UsuarioCreacion]
GO
ALTER TABLE [Acc].[tbUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuarios_tbUsuarios_UsuarioModificacion] FOREIGN KEY([Usua_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Acc].[tbUsuarios] CHECK CONSTRAINT [FK_tbUsuarios_tbUsuarios_UsuarioModificacion]
GO
ALTER TABLE [Grl].[tbCiudades]  WITH CHECK ADD  CONSTRAINT [FK_tbCiudades_tbEstartamentos_Esta_Id] FOREIGN KEY([Esta_Id])
REFERENCES [Grl].[tbEstados] ([Esta_Id])
GO
ALTER TABLE [Grl].[tbCiudades] CHECK CONSTRAINT [FK_tbCiudades_tbEstartamentos_Esta_Id]
GO
ALTER TABLE [Grl].[tbCiudades]  WITH CHECK ADD  CONSTRAINT [FK_tbCiudades_tbUsuarios_UsuarioCreacion] FOREIGN KEY([Ciud_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbCiudades] CHECK CONSTRAINT [FK_tbCiudades_tbUsuarios_UsuarioCreacion]
GO
ALTER TABLE [Grl].[tbCiudades]  WITH CHECK ADD  CONSTRAINT [FK_tbCiudades_tbUsuarios_UsuarioModificacion] FOREIGN KEY([Ciud_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbCiudades] CHECK CONSTRAINT [FK_tbCiudades_tbUsuarios_UsuarioModificacion]
GO
ALTER TABLE [Grl].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tbEmpleados_tbCargos_Carg_Id] FOREIGN KEY([Carg_Id])
REFERENCES [Pro].[tbCargos] ([Carg_Id])
GO
ALTER TABLE [Grl].[tbEmpleados] CHECK CONSTRAINT [FK_tbEmpleados_tbCargos_Carg_Id]
GO
ALTER TABLE [Grl].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tbEmpleados_tbCiudades_Ciud_Id] FOREIGN KEY([Ciud_id])
REFERENCES [Grl].[tbCiudades] ([Ciud_Id])
GO
ALTER TABLE [Grl].[tbEmpleados] CHECK CONSTRAINT [FK_tbEmpleados_tbCiudades_Ciud_Id]
GO
ALTER TABLE [Grl].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tbEmpleados_tbEstadosCiviles_Estc_Id] FOREIGN KEY([Estc_Id])
REFERENCES [Grl].[tbEstadosCiviles] ([Estc_Id])
GO
ALTER TABLE [Grl].[tbEmpleados] CHECK CONSTRAINT [FK_tbEmpleados_tbEstadosCiviles_Estc_Id]
GO
ALTER TABLE [Grl].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tbEmpleados_tbUsuarios_UsuarioCreacion] FOREIGN KEY([Empl_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbEmpleados] CHECK CONSTRAINT [FK_tbEmpleados_tbUsuarios_UsuarioCreacion]
GO
ALTER TABLE [Grl].[tbEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tbEmpleados_tbUsuarios_UsuarioModificacion] FOREIGN KEY([Empl_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbEmpleados] CHECK CONSTRAINT [FK_tbEmpleados_tbUsuarios_UsuarioModificacion]
GO
ALTER TABLE [Grl].[tbEmpresas]  WITH CHECK ADD  CONSTRAINT [FK_tbEmpresas_tbCiudades_Ciud_Id] FOREIGN KEY([Ciud_Id])
REFERENCES [Grl].[tbCiudades] ([Ciud_Id])
GO
ALTER TABLE [Grl].[tbEmpresas] CHECK CONSTRAINT [FK_tbEmpresas_tbCiudades_Ciud_Id]
GO
ALTER TABLE [Grl].[tbEmpresas]  WITH CHECK ADD  CONSTRAINT [FK_tbEmpresas_tbUsuarios_Empre_UsuarioCreacion] FOREIGN KEY([Empre_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbEmpresas] CHECK CONSTRAINT [FK_tbEmpresas_tbUsuarios_Empre_UsuarioCreacion]
GO
ALTER TABLE [Grl].[tbEmpresas]  WITH CHECK ADD  CONSTRAINT [FK_tbEmpresas_tbUsuarios_Empre_UsuarioModificacion] FOREIGN KEY([Empre_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbEmpresas] CHECK CONSTRAINT [FK_tbEmpresas_tbUsuarios_Empre_UsuarioModificacion]
GO
ALTER TABLE [Grl].[tbEstados]  WITH CHECK ADD  CONSTRAINT [FK_tbEstados_tbUsuarios_UsuarioCreacion] FOREIGN KEY([Esta_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbEstados] CHECK CONSTRAINT [FK_tbEstados_tbUsuarios_UsuarioCreacion]
GO
ALTER TABLE [Grl].[tbEstados]  WITH CHECK ADD  CONSTRAINT [FK_tbEstados_tbUsuarios_UsuarioModificacion] FOREIGN KEY([Esta_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbEstados] CHECK CONSTRAINT [FK_tbEstados_tbUsuarios_UsuarioModificacion]
GO
ALTER TABLE [Grl].[tbEstadosCiviles]  WITH CHECK ADD  CONSTRAINT [FK_tbEstadosCiviles_tbUsuarios_UsuarioCreacion] FOREIGN KEY([Estc_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbEstadosCiviles] CHECK CONSTRAINT [FK_tbEstadosCiviles_tbUsuarios_UsuarioCreacion]
GO
ALTER TABLE [Grl].[tbEstadosCiviles]  WITH CHECK ADD  CONSTRAINT [FK_tbEstadosCiviles_tbUsuarios_UsuarioModificacion] FOREIGN KEY([Estc_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbEstadosCiviles] CHECK CONSTRAINT [FK_tbEstadosCiviles_tbUsuarios_UsuarioModificacion]
GO
ALTER TABLE [Grl].[tbParticipantes]  WITH CHECK ADD  CONSTRAINT [FK_tbParticipantes_tbCiudades_Ciud_Id] FOREIGN KEY([Ciud_id])
REFERENCES [Grl].[tbCiudades] ([Ciud_Id])
GO
ALTER TABLE [Grl].[tbParticipantes] CHECK CONSTRAINT [FK_tbParticipantes_tbCiudades_Ciud_Id]
GO
ALTER TABLE [Grl].[tbParticipantes]  WITH CHECK ADD  CONSTRAINT [FK_tbParticipantes_tbEmpresas_Empre_Id] FOREIGN KEY([Empre_Id])
REFERENCES [Grl].[tbEmpresas] ([Empre_Id])
GO
ALTER TABLE [Grl].[tbParticipantes] CHECK CONSTRAINT [FK_tbParticipantes_tbEmpresas_Empre_Id]
GO
ALTER TABLE [Grl].[tbParticipantes]  WITH CHECK ADD  CONSTRAINT [FK_tbParticipantes_tbEstadosCiviles_Estc_Id] FOREIGN KEY([Estc_Id])
REFERENCES [Grl].[tbEstadosCiviles] ([Estc_Id])
GO
ALTER TABLE [Grl].[tbParticipantes] CHECK CONSTRAINT [FK_tbParticipantes_tbEstadosCiviles_Estc_Id]
GO
ALTER TABLE [Grl].[tbParticipantes]  WITH CHECK ADD  CONSTRAINT [FK_tbParticipantes_tbUsuarios_Part_UsuarioCreacion] FOREIGN KEY([Part_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbParticipantes] CHECK CONSTRAINT [FK_tbParticipantes_tbUsuarios_Part_UsuarioCreacion]
GO
ALTER TABLE [Grl].[tbParticipantes]  WITH CHECK ADD  CONSTRAINT [FK_tbParticipantes_tbUsuarios_Part_UsuarioModificacion] FOREIGN KEY([Part_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Grl].[tbParticipantes] CHECK CONSTRAINT [FK_tbParticipantes_tbUsuarios_Part_UsuarioModificacion]
GO
ALTER TABLE [Pro].[tbCargos]  WITH CHECK ADD  CONSTRAINT [FK_tbCargos_tbUsuarios_Carg_UsuarioCreacion] FOREIGN KEY([Carg_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbCargos] CHECK CONSTRAINT [FK_tbCargos_tbUsuarios_Carg_UsuarioCreacion]
GO
ALTER TABLE [Pro].[tbCargos]  WITH CHECK ADD  CONSTRAINT [FK_tbCargos_tbUsuarios_Carg_UsuarioModificacion] FOREIGN KEY([Carg_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbCargos] CHECK CONSTRAINT [FK_tbCargos_tbUsuarios_Carg_UsuarioModificacion]
GO
ALTER TABLE [Pro].[tbCategorias]  WITH CHECK ADD  CONSTRAINT [FK_tbCategorias_tbUsuarios_Cate_UsuarioCreacion] FOREIGN KEY([Cate_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbCategorias] CHECK CONSTRAINT [FK_tbCategorias_tbUsuarios_Cate_UsuarioCreacion]
GO
ALTER TABLE [Pro].[tbCategorias]  WITH CHECK ADD  CONSTRAINT [FK_tbCategorias_tbUsuarios_Cate_UsuarioModificacion] FOREIGN KEY([Cate_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbCategorias] CHECK CONSTRAINT [FK_tbCategorias_tbUsuarios_Cate_UsuarioModificacion]
GO
ALTER TABLE [Pro].[tbContenido]  WITH CHECK ADD  CONSTRAINT [FK_tbContenido_tbUsuarios_Cont_UsuarioCreacion] FOREIGN KEY([Cont_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbContenido] CHECK CONSTRAINT [FK_tbContenido_tbUsuarios_Cont_UsuarioCreacion]
GO
ALTER TABLE [Pro].[tbContenido]  WITH CHECK ADD  CONSTRAINT [FK_tbContenido_tbUsuarios_Cont_UsuarioModificacion] FOREIGN KEY([Cont_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbContenido] CHECK CONSTRAINT [FK_tbContenido_tbUsuarios_Cont_UsuarioModificacion]
GO
ALTER TABLE [Pro].[tbContenidoPorCurso]  WITH CHECK ADD  CONSTRAINT [FK_tbContenidoPorCurso_tbContenido_Cont_Id] FOREIGN KEY([Cont_Id])
REFERENCES [Pro].[tbContenido] ([Cont_Id])
GO
ALTER TABLE [Pro].[tbContenidoPorCurso] CHECK CONSTRAINT [FK_tbContenidoPorCurso_tbContenido_Cont_Id]
GO
ALTER TABLE [Pro].[tbContenidoPorCurso]  WITH CHECK ADD  CONSTRAINT [FK_tbContenidoPorCurso_tbCurso_Curso_Id] FOREIGN KEY([Curso_Id])
REFERENCES [Pro].[tbCursos] ([Curso_Id])
GO
ALTER TABLE [Pro].[tbContenidoPorCurso] CHECK CONSTRAINT [FK_tbContenidoPorCurso_tbCurso_Curso_Id]
GO
ALTER TABLE [Pro].[tbContenidoPorCurso]  WITH CHECK ADD  CONSTRAINT [FK_tbContenidoPorCurso_tbUsuarios_ConPc_UsuarioCreacion] FOREIGN KEY([ConPc_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbContenidoPorCurso] CHECK CONSTRAINT [FK_tbContenidoPorCurso_tbUsuarios_ConPc_UsuarioCreacion]
GO
ALTER TABLE [Pro].[tbContenidoPorCurso]  WITH CHECK ADD  CONSTRAINT [FK_tbContenidoPorCurso_tbUsuarios_ConPc_UsuarioModificacion] FOREIGN KEY([ConPc_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbContenidoPorCurso] CHECK CONSTRAINT [FK_tbContenidoPorCurso_tbUsuarios_ConPc_UsuarioModificacion]
GO
ALTER TABLE [Pro].[tbCursos]  WITH CHECK ADD  CONSTRAINT [FK_tbCursos_tbCategorias_Cate_Id] FOREIGN KEY([Cate_Id])
REFERENCES [Pro].[tbCategorias] ([Cate_Id])
GO
ALTER TABLE [Pro].[tbCursos] CHECK CONSTRAINT [FK_tbCursos_tbCategorias_Cate_Id]
GO
ALTER TABLE [Pro].[tbCursos]  WITH CHECK ADD  CONSTRAINT [FK_tbCursos_tbUsuarios_Curso_UsuarioCreacion] FOREIGN KEY([Curso_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbCursos] CHECK CONSTRAINT [FK_tbCursos_tbUsuarios_Curso_UsuarioCreacion]
GO
ALTER TABLE [Pro].[tbCursos]  WITH CHECK ADD  CONSTRAINT [FK_tbCursos_tbUsuarios_Curso_UsuarioModificacion] FOREIGN KEY([Curso_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbCursos] CHECK CONSTRAINT [FK_tbCursos_tbUsuarios_Curso_UsuarioModificacion]
GO
ALTER TABLE [Pro].[tbCursosImpartidos]  WITH CHECK ADD  CONSTRAINT [FK_tbCursosImpartidos_tbCursos_Curso_Id] FOREIGN KEY([Curso_Id])
REFERENCES [Pro].[tbCursos] ([Curso_Id])
GO
ALTER TABLE [Pro].[tbCursosImpartidos] CHECK CONSTRAINT [FK_tbCursosImpartidos_tbCursos_Curso_Id]
GO
ALTER TABLE [Pro].[tbCursosImpartidos]  WITH CHECK ADD  CONSTRAINT [FK_tbCursosImpartidos_tbEmpleados_Empl_Id] FOREIGN KEY([Empl_Id])
REFERENCES [Grl].[tbEmpleados] ([Empl_Id])
GO
ALTER TABLE [Pro].[tbCursosImpartidos] CHECK CONSTRAINT [FK_tbCursosImpartidos_tbEmpleados_Empl_Id]
GO
ALTER TABLE [Pro].[tbCursosImpartidos]  WITH CHECK ADD  CONSTRAINT [FK_tbCursosImpartidos_tbUsuarios_CurIm_UsuarioCreacion] FOREIGN KEY([CurIm_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbCursosImpartidos] CHECK CONSTRAINT [FK_tbCursosImpartidos_tbUsuarios_CurIm_UsuarioCreacion]
GO
ALTER TABLE [Pro].[tbCursosImpartidos]  WITH CHECK ADD  CONSTRAINT [FK_tbCursosImpartidos_tbUsuarios_CurIm_UsuarioModificacion] FOREIGN KEY([CurIm_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbCursosImpartidos] CHECK CONSTRAINT [FK_tbCursosImpartidos_tbUsuarios_CurIm_UsuarioModificacion]
GO
ALTER TABLE [Pro].[tbInformeEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tbInformeEmpleados_tbCursos_Curso_Id] FOREIGN KEY([Curso_Id])
REFERENCES [Pro].[tbCursos] ([Curso_Id])
GO
ALTER TABLE [Pro].[tbInformeEmpleados] CHECK CONSTRAINT [FK_tbInformeEmpleados_tbCursos_Curso_Id]
GO
ALTER TABLE [Pro].[tbInformeEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tbInformeEmpleados_tbEmpleados_Emp_Id] FOREIGN KEY([Empl_Id])
REFERENCES [Grl].[tbEmpleados] ([Empl_Id])
GO
ALTER TABLE [Pro].[tbInformeEmpleados] CHECK CONSTRAINT [FK_tbInformeEmpleados_tbEmpleados_Emp_Id]
GO
ALTER TABLE [Pro].[tbTitulos]  WITH CHECK ADD  CONSTRAINT [FK_tbTitulos_tbUsuarios_Titl_UsuarioCreacion] FOREIGN KEY([Titl_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbTitulos] CHECK CONSTRAINT [FK_tbTitulos_tbUsuarios_Titl_UsuarioCreacion]
GO
ALTER TABLE [Pro].[tbTitulos]  WITH CHECK ADD  CONSTRAINT [FK_tbTitulos_tbUsuarios_Titl_UsuarioModificacion] FOREIGN KEY([Titl_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbTitulos] CHECK CONSTRAINT [FK_tbTitulos_tbUsuarios_Titl_UsuarioModificacion]
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_tbTitulosPorEmpleado_tbEmpleados_Empl_Id] FOREIGN KEY([Empl_Id])
REFERENCES [Grl].[tbEmpleados] ([Empl_Id])
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado] CHECK CONSTRAINT [FK_tbTitulosPorEmpleado_tbEmpleados_Empl_Id]
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_tbTitulosPorEmpleado_tbTitulos_Titl_Id] FOREIGN KEY([Titl_Id])
REFERENCES [Pro].[tbTitulos] ([Titl_Id])
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado] CHECK CONSTRAINT [FK_tbTitulosPorEmpleado_tbTitulos_Titl_Id]
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_tbTitulosPorEmpleado_tbUsuarios_TitPe_UsuarioCreacion] FOREIGN KEY([TitPe_UsuarioCreacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado] CHECK CONSTRAINT [FK_tbTitulosPorEmpleado_tbUsuarios_TitPe_UsuarioCreacion]
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_tbTitulosPorEmpleado_tbUsuarios_TitPe_UsuarioModificacion] FOREIGN KEY([TitPe_UsuarioModificacion])
REFERENCES [Acc].[tbUsuarios] ([Usua_Id])
GO
ALTER TABLE [Pro].[tbTitulosPorEmpleado] CHECK CONSTRAINT [FK_tbTitulosPorEmpleado_tbUsuarios_TitPe_UsuarioModificacion]
GO
/****** Object:  StoredProcedure [Acc].[SP_Pantallas_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Pantallas_Actualizar]
    @Pant_Id INT,
    @Pant_Descripcion VARCHAR(60),
    @Pant_UsuarioModificacion INT,
    @Pant_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        UPDATE Acc.tbPantallas
        SET Pant_Descripcion = @Pant_Descripcion,
            Pant_UsuarioModificacion = @Pant_UsuarioModificacion,
            Pant_FechaModificacion = @Pant_FechaModificacion
        WHERE Pant_Id = @Pant_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;


GO
/****** Object:  StoredProcedure [Acc].[SP_Pantallas_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Pantallas_Eliminar]
    @Pant_Id INT
AS
BEGIN
    BEGIN TRY
        UPDATE Acc.tbPantallas
        SET Pant_Estado = 0
        WHERE Pant_Id = @Pant_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;


GO
/****** Object:  StoredProcedure [Acc].[SP_Pantallas_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Pantallas_Insertar]
    @Pant_Descripcion VARCHAR(60),
    @Pant_UsuarioCreacion INT,
    @Pant_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        INSERT INTO Acc.tbPantallas (
            Pant_Descripcion,
            Pant_UsuarioCreacion,
            Pant_FechaCreacion
        )
        VALUES (
            @Pant_Descripcion,
            @Pant_UsuarioCreacion,
            @Pant_FechaCreacion
        );
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Pantallas_Listado]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Acc].[SP_Pantallas_Listado] 
    @Role_Id INT
AS
BEGIN
    SELECT Pan.Pant_Id, Pan.Pant_Descripcion
    FROM Acc.tbPantallas AS Pan
    WHERE Pan.Pant_Estado = 1
      AND NOT EXISTS (
          SELECT 1
          FROM Acc.tbPantallasPorRoles AS PxR
          WHERE PxR.Role_Id = @Role_Id AND PxR.Pant_Id = Pan.Pant_Id
      )
END
GO
/****** Object:  StoredProcedure [Acc].[SP_Pantallas_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Pantallas_LlenarEditar]
	@Pant_Id INT
AS
BEGIN
    SELECT *
    FROM Acc.tbPantallas
    WHERE Pant_Id = @Pant_Id
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Pantallas_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Pantallas_Seleccionar]
AS
BEGIN
    SELECT Pan.Pant_Id, Pan.Pant_Descripcion
    FROM Acc.tbPantallas AS Pan
    WHERE Pan.Pant_Estado = 1
     
END

GO
/****** Object:  StoredProcedure [Acc].[SP_PantallasPorRoles_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_PantallasPorRoles_Actualizar]
    @PaPr_Id INT,
    @Pant_Id INT,
    @Role_Id INT,
    @PaPr_UsuarioModificacion INT,
    @PaPr_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        UPDATE Acc.tbPantallasPorRoles
        SET Pant_Id = @Pant_Id,
            Role_Id = @Role_Id,
            PaPr_UsuarioModificacion = @PaPr_UsuarioModificacion,
            PaPr_FechaModificacion = @PaPr_FechaModificacion
        WHERE PaPr_Id = @PaPr_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_PantallasPorRoles_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_PantallasPorRoles_Eliminar]
   	@PaPr_Id INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM acc.tbPantallasPorRoles
	WHERE  PaPr_Id = @PaPr_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Acc].[SP_PantallasPorRoles_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_PantallasPorRoles_Insertar]
    @Pant_Id INT,
    @Role_Id INT,
    @PaPr_UsuarioCreacion INT,
    @PaPr_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        INSERT INTO Acc.tbPantallasPorRoles (
            Pant_Id,
            Role_Id,
            PaPr_UsuarioCreacion,
            PaPr_FechaCreacion
        )
        VALUES (
            @Pant_Id,
            @Role_Id,
            @PaPr_UsuarioCreacion,
            @PaPr_FechaCreacion
        );
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_PantallasPorRoles_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_PantallasPorRoles_LlenarEditar]
	@PaPr_Id INT
AS
BEGIN
    SELECT *
    FROM Acc.tbPantallasPorRoles
    WHERE PaPr_Id = @PaPr_Id
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_PantallasPorRoles_Mostrar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[Acc].[SP_PantallasPorRoles_Mostrar]
@Role_Id INT
AS
BEGIN
	SELECT  PaPr_Id, PanRo.Pant_Id, Pant_Descripcion
	FROM Acc.tbPantallasPorRoles AS PanRo 
	INNER JOIN Acc.tbPantallas AS PAN ON PAN.Pant_Id = PanRo.Pant_Id
	WHERE Role_Id = @Role_Id and Pan.Pant_Estado = 1
END
GO
/****** Object:  StoredProcedure [Acc].[SP_PantallasPorRoles_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_PantallasPorRoles_Seleccionar]
@Role_Id INT
AS
BEGIN
	SELECT	PanRo.Role_Id,
			R.Role_Descripcion as Rol,
			PAN.Pant_Id,
			Pant_Descripcion AS Pantalla
	FROM Acc.tbPantallasPorRoles AS PanRo INNER JOIN Acc.tbPantallas AS PAN 
	ON PAN.Pant_Id = PanRo.Pant_Id inner join Acc.tbRoles As R
	On R.Role_Id = PanRo.Role_Id
	WHERE  Pan.Pant_Estado = 1 AND PanRo.Role_Id = @Role_Id
END

GO
/****** Object:  StoredProcedure [Acc].[SP_Roles_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Roles_Actualizar]
    @Role_Id INT,
    @Role_Descripcion VARCHAR(30),
    @Role_UsuarioModificacion INT,
    @Role_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        UPDATE Acc.tbRoles
        SET Role_Descripcion = @Role_Descripcion,
            Role_UsuarioModificacion = @Role_UsuarioModificacion,
            Role_FechaModificacion = @Role_FechaModificacion
        WHERE Role_Id = @Role_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Roles_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Roles_Eliminar]
    @Role_Id INT
AS
BEGIN
    BEGIN TRY
        UPDATE Acc.tbRoles
        SET Role_Estado = 0
        WHERE Role_Id = @Role_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Roles_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Roles_Insertar]
    @Role_Descripcion VARCHAR(30),
    @Role_UsuarioCreacion INT,
    @Role_FechaCreacion DATETIME,
	@role_id int OUTPUT
AS
BEGIN
  DECLARE @estadoActual INT;

   SELECT @estadoActual = Role_estado FROM Acc.tbRoles WHERE Role_Descripcion = @Role_Descripcion;
   BEGIN TRY 
      IF @estadoActual IS NOT NULL
	     BEGIN
       
            IF @estadoActual = 0
            BEGIN
                -- El estado es 0, actualiza el estado a 1
                UPDATE Acc.tbRoles SET Role_Estado = 1 WHERE Role_Descripcion = @Role_Descripcion;
                SELECT 1
            END
            ELSE
            BEGIN
      
                SELECT 0;
            END
        END
		 ELSE
        BEGIN
	INSERT INTO Acc.tbRoles (Role_Descripcion,Role_UsuarioCreacion,Role_FechaCreacion)
	VALUES( @Role_Descripcion, @Role_UsuarioCreacion, @Role_FechaCreacion)
	SET @role_id = SCOPE_IDENTITY();
	SELECT 1
	END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Roles_LLenar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [Acc].[SP_Roles_LLenar]
@Rol_Id INT
AS
BEGIN
	SELECT	Role_Id,
				Role_Descripcion,
				Role_UsuarioCreacion,
				Role_UsuarioModificacion,
				Role_FechaCreacion,
				Role_FechaModificacion
	FROM Acc.tbRoles AS Rol
	WHERE Rol.Role_Estado = 1 AND Role_Id = @Rol_Id
END

GO
/****** Object:  StoredProcedure [Acc].[SP_Roles_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Roles_LlenarEditar]
	@Role_Id INT
AS
BEGIN
    SELECT 
	r.[Role_Id],
	[Role_Descripcion],
	u1.Usua_Usuario UsuarioCreacion,
	[Role_FechaCreacion],
	u2.Usua_Usuario UsuarioModificacion,
	[Role_FechaModificacion]
    FROM Acc.tbRoles r inner join Acc.tbUsuarios u1
	on u1.Usua_Id = r.Role_UsuarioCreacion left join Acc.tbUsuarios u2
	on u2.Usua_Id = r.Role_UsuarioModificacion
    WHERE r.Role_Id = @Role_Id
END;
GO
/****** Object:  StoredProcedure [Acc].[SP_Roles_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Roles_Seleccionar]
AS
BEGIN
    SELECT Role_Id, Role_Descripcion, Role_UsuarioCreacion, Role_FechaCreacion, Role_UsuarioModificacion, Role_FechaModificacion, Role_Estado
    FROM Acc.tbRoles
    WHERE Role_Estado = 1;
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Acc].[SP_Usuarios_Actualizar]
    @Usua_Id INT,
    @Usua_Usuario VARCHAR(60),
    @Usua_EsAdmin BIT,
    @Empl_Id INT,
    @Role_Id INT,
    @Usua_UsuarioModificacion INT,
    @Usua_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        UPDATE Acc.tbUsuarios
        SET Usua_Usuario = @Usua_Usuario,
            Usua_EsAdmin = @Usua_EsAdmin,
            Empl_Id = @Empl_Id,
            Role_Id = @Role_Id,
            Usua_UsuarioModificacion = @Usua_UsuarioModificacion,
            Usua_FechaModificacion = @Usua_FechaModificacion
        WHERE Usua_Id = @Usua_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_Detalles]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Acc].[SP_Usuarios_Detalles]  
 @Usua_Id INT
 AS
 BEGIN
 SELECT 
 USUA.Usua_Id,
 USUA.Usua_Usuario,
 USUA.Usua_FechaCreacion,
 USUA.Usua_FechaModificacion,
 USUA.Usua_EsAdmin, 
 CASE WHEN USUA.Usua_UsuarioCreacion = USU.Usua_Id THEN USUA.Usua_Usuario ELSE USUA.Usua_Usuario END AS UsuarioCreacion,
 CASE WHEN USUA.Usua_UsuarioModificacion = USU.Usua_Id THEN USU.Usua_Usuario ELSE 'Sin Modificar' END AS UsuarioModificacion,
 PERS.Empl_Id, Empl_DNI, Empl_Nombre, Empl_Apellido, 
 ROL.Role_Id, Role_Descripcion 
 FROM Acc.tbUsuarios AS USUA 
      INNER JOIN Grl.tbEmpleados AS PERS ON USUA.Empl_Id = PERS.Empl_Id
	  INNER JOIN Acc.tbRoles AS ROL ON USUA.Role_Id = ROL.Role_Id
	  	   	  LEFT JOIN Acc.tbUsuarios AS USU ON USUA.Usua_UsuarioModificacion = USU.Usua_Id	  

	  WHERE USUA.Usua_Id = @Usua_Id
END
GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Usuarios_Eliminar]
    @Usua_Id INT
AS
BEGIN
    BEGIN TRY
        UPDATE Acc.tbUsuarios
        SET Usua_Estado = 0
        WHERE Usua_Id = @Usua_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_EnviarCorreo]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create     procedure [Acc].[SP_Usuarios_EnviarCorreo]
@UsuarioCorreo varchar(70)
as
begin
	select 
	[Usua_Id],
	[Usua_Usuario],
	E.[Empl_Correo] correo
	from [Acc].[tbUsuarios] U left join [Grl].[tbEmpleados] E
	on U.Empl_Id = E.Empl_Id
	where [Usua_Usuario] = @UsuarioCorreo OR E.Empl_Correo = @UsuarioCorreo
end
GO
/****** Object:  StoredProcedure [Acc].[sp_Usuarios_IngresarCodigo]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create     procedure [Acc].[sp_Usuarios_IngresarCodigo]
@Usua_Id INT,
@Usua_VerificarCorreo varchar(max)
as
begin
	update [Acc].[tbUsuarios]
	set
	Usua_VerificarCorreo = @Usua_VerificarCorreo
	where Usua_Id = @Usua_Id
end
GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Acc].[SP_Usuarios_Insertar]
    @Usua_Usuario VARCHAR(60),
    @Usua_Contraseña VARCHAR(MAX),
    @Usua_EsAdmin BIT,
	@Empl_Id INT,
	@Role_Id INT,
    @Usua_UsuarioCreacion INT,
    @Usua_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        INSERT INTO Acc.tbUsuarios (
            Usua_Usuario,
            Usua_Contraseña,
            Usua_EsAdmin,
            Empl_Id,
			Role_Id,
            Usua_UsuarioCreacion,
            Usua_FechaCreacion
        )
        VALUES (
            @Usua_Usuario,
			CONVERT (VARCHAR (MAX), HASHBYTES ('SHA2_512', @Usua_Contraseña), 2),
            @Usua_EsAdmin,
			@Empl_Id,
			@Role_Id,
            @Usua_UsuarioCreacion,
            @Usua_FechaCreacion
        );
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_InsertarValidar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Acc].[SP_Usuarios_InsertarValidar]
    @Usua_Usuario VARCHAR(60),
    @Usua_ValidarCorreo VARCHAR(MAX)

AS
BEGIN
    BEGIN TRY
        UPDATE Acc.tbUsuarios
        SET Usua_VerificarCorreo = @Usua_ValidarCorreo
        WHERE Usua_Usuario = @Usua_Usuario;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Acc].[SP_Usuarios_LlenarEditar]
	@Usua_Id INT
AS
BEGIN
    SELECT *
    FROM Acc.tbUsuarios USU inner join Acc.tbRoles ROL on USU.Role_Id = ROL.Role_Id
	inner join Grl.tbEmpleados PERS on USU.Empl_Id = PERS.Empl_Id

    WHERE Usua_Id = @Usua_Id
END;
GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_ObtenerCorreo]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Acc].[SP_Usuarios_ObtenerCorreo]
	@Usua_Usuario VARCHAR(60)
AS
BEGIN
    SELECT Usua_Usuario, Empl_Nombre, Empl_Correo
    FROM Acc.tbUsuarios USU	inner join Grl.tbEmpleados PERS on USU.Empl_Id = PERS.Empl_Id

    WHERE Usua_Usuario = @Usua_Usuario
END;
GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_Reestablecer]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Acc].[SP_Usuarios_Reestablecer]
(
	@Usua_Id int,
    @Usua_Contraseña VARCHAR(MAX),
    @Usua_UsuarioModificacion INT, 
    @Usua_FechaModificacion DATETIME
)
AS
BEGIN
    BEGIN TRY
	UPDATE Acc.tbUsuarios
			SET Usua_Contraseña = CONVERT (VARCHAR (MAX), HASHBYTES ('SHA2_512', @Usua_Contraseña), 2),
			
				Usua_UsuarioModificacion = @Usua_UsuarioModificacion,
				Usua_FechaModificacion = @Usua_FechaModificacion
			WHERE Usua_Id = @Usua_Id

        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_ReestablecerContraseña]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Acc].[SP_Usuarios_ReestablecerContraseña]
(
    @Usua_id INT,
	@CodigoVerificacion VARCHAR(MAX),
    @Usua_Contraseña VARCHAR(MAX),
    @Usua_UsuarioModificacion INT, 
    @Usua_FechaModificacion DATETIME
)
AS
BEGIN
    BEGIN TRY
	-- FASE BETA --
		IF(@CodigoVerificacion = 123)
		BEGIN
			UPDATE Acc.tbUsuarios
			SET Usua_Contraseña = CONVERT (VARCHAR (MAX), HASHBYTES ('SHA2_512', @Usua_Contraseña), 2),
			
				Usua_UsuarioModificacion = @Usua_UsuarioModificacion,
				Usua_FechaModificacion = @Usua_FechaModificacion
			WHERE Usua_id = @Usua_id
		END

        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Acc].[SP_Usuarios_Seleccionar] 
AS
BEGIN
    SELECT 
	Usua_Id,
	Usua_Usuario,
	Usua_Contraseña, 
	Usua_EsAdmin,
	Usua_VerificarCorreo,
	CASE Usua_EsAdmin WHEN 1 THEN 'Si' WHEN 0 THEN 'No' END Usua_Admin1,
	Role_Descripcion,
	CONCAT(Empl_Nombre, ' ', Empl_Apellido) Empl_Nombre,
	Empl_Correo as correo
    FROM Acc.tbUsuarios USU
	left join Acc.tbRoles ROL on USU.Role_Id = ROL.Role_Id
	left  join Grl.tbEmpleados PERS on USU.Empl_Id = PERS.Empl_Id


    WHERE Usua_Estado = 1;
END;

GO
/****** Object:  StoredProcedure [Acc].[SP_Usuarios_ValidarCodigo]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     procedure [Acc].[SP_Usuarios_ValidarCodigo]
@Usua_VerificarCorreo varchar(max)
as
begin
begin try
	update [Acc].[tbUsuarios]
	set
		[Usua_VerificarCorreo] = null
	where [Usua_Estado]  = 1 and [Usua_VerificarCorreo] = @Usua_VerificarCorreo
	select 1;
	
	end try
	begin catch
	select 0
	end catch
end
GO
/****** Object:  StoredProcedure [Acc].[SP_UsuariosValidarInicioSesion]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Acc].[SP_UsuariosValidarInicioSesion] 
	@Usuario VARCHAR(30),
	@Contraseña VARCHAR(max)
AS
BEGIN 
	SELECT	usu.Usua_id,
			usu.usua_Usuario,
			usu.usua_Contraseña,
			PR.Role_Id,
			p.Pant_Descripcion,
			usu.Usua_EsAdmin,
			EM.Empl_Id,
			EM.Empl_Correo,
			Concat(EM.Empl_Nombre, ' ', EM.Empl_Apellido) Empl_Nombre
	FROM Acc.tbUsuarios AS usu left JOIN Acc.tbPantallasPorRoles AS PR ON PR.role_id = usu.role_id left JOIN Acc.tbPantallas AS P ON P.Pant_Id = PR.Pant_Id
		inner join Grl.tbEmpleados EM ON EM.Empl_Id = usu.Empl_Id
		
	WHERE usu.Usua_Usuario = @Usuario AND usu.Usua_Contraseña = CONVERT (VARCHAR (MAX), HASHBYTES ('SHA2_512', @Contraseña), 2);
END
GO
/****** Object:  StoredProcedure [Grl].[SP_Ciudades_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Grl].[SP_Ciudades_Actualizar]
    @Ciud_Id VARCHAR(4),
    @Ciud_Descripcion VARCHAR(40),
    @Esta_Id VARCHAR(2),
    @Ciud_UsuarioModificacion INT,
    @Ciud_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        UPDATE Grl.tbCiudades
        SET Ciud_Descripcion = @Ciud_Descripcion,
            Esta_Id = @Esta_Id,
            Ciud_UsuarioModificacion = @Ciud_UsuarioModificacion,
            Ciud_FechaModificacion = @Ciud_FechaModificacion
        WHERE Ciud_Id = @Ciud_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_Ciudades_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_Ciudades_Eliminar]
    @Ciud_Id VARCHAR(4)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Grl.tbCiudades
        WHERE Ciud_Id = @Ciud_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_Ciudades_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_Ciudades_Insertar]
    @Ciud_Id VARCHAR(4),
    @Ciud_Descripcion VARCHAR(40),
    @Esta_Id VARCHAR(2),
    @Ciud_UsuarioCreacion INT,
    @Ciud_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        INSERT INTO Grl.tbCiudades (
            Ciud_Id,
            Ciud_Descripcion,
            Esta_Id,
            Ciud_UsuarioCreacion,
            Ciud_FechaCreacion
        )
        VALUES (
            @Ciud_Id,
            @Ciud_Descripcion,
            @Esta_Id,
            @Ciud_UsuarioCreacion,
            @Ciud_FechaCreacion
        );
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_Ciudades_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Grl].[SP_Ciudades_LlenarEditar]
	@Ciud_Id INT
AS
BEGIN
    SELECT *,
	 CASE WHEN Ciud_UsuarioCreacion = Usua_Id THEN usu.Usua_Usuario ELSE usu.Usua_Usuario END AS UsuarioCreacion,
 CASE WHEN Ciud_UsuarioModificacion = Usua_Id THEN usu.Usua_Usuario ELSE 'Sin Modificar' END AS UsuarioModificacion
    FROM Grl.tbCiudades ciud inner join grl.tbEstados esta on ciud.Esta_Id = esta.Esta_Id
		inner join Acc.tbUsuarios usu on usu.Usua_UsuarioCreacion = ciud.Ciud_UsuarioCreacion
    WHERE Ciud_Id = @Ciud_Id
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Ciudades_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_Ciudades_Seleccionar]
AS
BEGIN
    SELECT 
	Ciud_Id,
	Ciud_Descripcion,
	Esta_Descripcion As Estado
    FROM Grl.tbCiudades inner join grl.tbEstados 
	on grl.tbCiudades.Esta_Id = grl.tbEstados.Esta_Id
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_CiudadesPorEstados]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Grl].[SP_CiudadesPorEstados]
@Esta_id VARCHAR(2)
AS
BEGIN
	SELECT * FROM Grl.tbCiudades 
	WHERE Esta_Id = @Esta_id
END
GO
/****** Object:  StoredProcedure [Grl].[SP_CiudadesPorEstados_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_CiudadesPorEstados_Seleccionar]
(
 @Esta_Id VARCHAR(2)
)
AS
BEGIN
    SELECT [Ciud_Id] ,[Ciud_Descripcion], MUN.Esta_Id
	FROM [Grl].[tbCiudades] MUN INNER JOIN [Grl].tbEstados EST ON EST.Esta_Id = MUN.Esta_Id
	WHERE MUN.Esta_Id = @Esta_Id;
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Empleados_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------

CREATE PROCEDURE [Grl].[SP_Empleados_Actualizar]
    @Empl_Id INT,
    @Empl_DNI VARCHAR(50),
	@Carg_Id INT,
    @Empl_Nombre VARCHAR(60),
    @Empl_Apellido VARCHAR(60),
	@Empl_Correo varchar(60),
    @Empl_FechaNacimiento DATE,
    @Empl_Sexo CHAR(1),
    @Estc_Id INT,
    @Empl_Direccion VARCHAR(60),
    @Ciud_Id VARCHAR(4),
    @Empl_UsuarioModificacion INT,
    @Empl_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        UPDATE Grl.tbEmpleados
        SET Empl_DNI = @Empl_DNI,
			Carg_Id = @Carg_Id,
            Empl_Nombre = @Empl_Nombre,
            Empl_Apellido = @Empl_Apellido,
			Empl_Correo = @Empl_Correo,
            Empl_FechaNacimiento = @Empl_FechaNacimiento,
            Empl_Sexo = @Empl_Sexo,
            Estc_Id = @Estc_Id,
            Empl_Direccion = @Empl_Direccion,
            Ciud_Id = @Ciud_Id,
            Empl_UsuarioModificacion = @Empl_UsuarioModificacion,
            Empl_FechaModificacion = @Empl_FechaModificacion
        WHERE Empl_Id = @Empl_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Empleados_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_Empleados_Eliminar]
    @Empl_Id INT
AS
BEGIN
    BEGIN TRY
        UPDATE Grl.tbEmpleados
        SET Empl_Estado = 0
        WHERE Empl_Id = @Empl_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Empleados_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Grl].[SP_Empleados_Insertar]
    @Empl_DNI VARCHAR(50),
	@Carg_Id INT,
    @Empl_Nombre VARCHAR(60),
    @Empl_Apellido VARCHAR(60),
	@Empl_Correo varchar(60),
    @Empl_FechaNacimiento DATE,
    @Empl_Sexo CHAR(1),
    @Estc_Id INT,
    @Empl_Direccion VARCHAR(60),
    @Ciud_Id VARCHAR(4),
	@Empl_UsuarioCreacion int,
    @Empl_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        INSERT INTO Grl.tbEmpleados (
            Empl_DNI,
			Carg_Id,
            Empl_Nombre,
            Empl_Apellido,
			Empl_Correo,
            Empl_FechaNacimiento,
            Empl_Sexo,
            Estc_Id,
            Empl_Direccion,
            Ciud_Id,
			Empl_UsuarioCreacion,
            Empl_FechaCreacion
        )
        VALUES (
            @Empl_DNI,
			@Carg_Id,
            @Empl_Nombre,
            @Empl_Apellido,
			@Empl_Correo,
            @Empl_FechaNacimiento,
            @Empl_Sexo,
            @Estc_Id,
            @Empl_Direccion,
            @Ciud_Id,
			@Empl_UsuarioCreacion,
            @Empl_FechaCreacion
        );
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Empleados_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Grl].[SP_Empleados_LlenarEditar] 
    @Empl_Id INT
AS
BEGIN 
    SELECT *, Carg_Descripcion cargo, case when Empl_Sexo = 'M' then 'Masculino'
	when Empl_Sexo = 'F' then 'Femenino' end Empl_Sexo, Estc_Descripcion estadoCivil,
		 CASE WHEN Empl_UsuarioCreacion = Usua_Id THEN usu.Usua_Usuario ELSE usu.Usua_Usuario END AS UsuarioCreacion,
	CASE WHEN Empl_UsuarioModificacion = Usua_Id THEN usu.Usua_Usuario ELSE 'Sin Modificar' END AS UsuarioModificacion
    FROM Grl.tbEmpleados EM inner join grl.tbEstadosCiviles EC on EM.Estc_Id = EC.Estc_Id
	inner join grl.tbCiudades MU on EM.Ciud_id = MU.Ciud_Id inner join Pro.tbCargos car
	on car.Carg_Id = em.Carg_Id inner join grl.tbEstados esta on MU.Esta_Id = esta.Esta_Id
	inner join Acc.tbUsuarios usu on usu.Usua_UsuarioCreacion = EM.Empl_UsuarioCreacion

    WHERE EM.Empl_Id = @Empl_Id and Empl_Estado = 1
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Empleados_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Grl].[SP_Empleados_Seleccionar]
AS
BEGIN
    SELECT Empl_Id,
	Empl_DNI,
	Carg_Descripcion As Cargo,
	Empl_Nombre,
	Empl_Apellido,
	Empl_Correo,
	Empl_FechaNacimiento,
	CASE Empl_Sexo WHEN 'F' THEN 'Femenino' WHEN 'M' THEN 'Masculino' END Sexo,
	Empl_SalarioHora,
	Empl_Direccion,
	Estc_Descripcion As EstadoCivil,
	Ciud_Descripcion as Ciudades
    FROM Grl.tbEmpleados EM inner join grl.tbEstadosCiviles EC 
	on EM.Estc_Id = EC.Estc_Id inner join grl.tbCiudades MU
	on EM.Ciud_id = MU.Ciud_Id left join [Pro].[tbCargos] ca
	On EM.Carg_Id = ca.Carg_Id
    WHERE Empl_Estado = 1 AND Empl_Id != 2;
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Estados_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_Estados_Actualizar]
    @Esta_Id VARCHAR(2),
    @Esta_Descripcion VARCHAR(40),
    @Esta_UsuarioModificacion INT,
    @Esta_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        UPDATE Grl.tbEstados
        SET Esta_Descripcion = @Esta_Descripcion,
            Esta_UsuarioModificacion = @Esta_UsuarioModificacion,
            Esta_FechaModificacion = @Esta_FechaModificacion
        WHERE Esta_Id = @Esta_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Estados_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_Estados_Eliminar]
    @Esta_Id VARCHAR(2)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Grl.tbEstados
        WHERE Esta_Id = @Esta_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Estados_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----
CREATE PROCEDURE [Grl].[SP_Estados_Insertar]
    @Esta_Id VARCHAR(2),
    @Esta_Descripcion VARCHAR(40),
    @Esta_UsuarioCreacion INT,
    @Esta_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        INSERT INTO Grl.tbEstados (
            Esta_Id,
            Esta_Descripcion,
            Esta_UsuarioCreacion,
            Esta_FechaCreacion
        )
        VALUES (
            @Esta_Id,
            @Esta_Descripcion,
            @Esta_UsuarioCreacion,
            @Esta_FechaCreacion
        );
        SELECT 1 AS DATO;
    END TRY
    BEGIN CATCH
        SELECT 0 AS DATO;
    END CATCH
END;


GO
/****** Object:  StoredProcedure [Grl].[SP_Estados_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Grl].[SP_Estados_LlenarEditar]
    @Esta_Id VARCHAR(2)
AS
BEGIN
    SELECT *,
	CASE WHEN Esta_UsuarioCreacion = Usua_Id THEN usu.Usua_Usuario ELSE usu.Usua_Usuario END AS UsuarioCreacion,
	CASE WHEN Esta_UsuarioModificacion = Usua_Id THEN usu.Usua_Usuario ELSE 'Sin Modificar' END AS UsuarioModificacion
    FROM Grl.tbEstados esta
		inner join Acc.tbUsuarios usu on usu.Usua_UsuarioCreacion = esta.esta_usuarioCreacion
    WHERE Esta_Id = @Esta_Id
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_Estados_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Grl].[SP_Estados_Seleccionar]
AS
BEGIN
    SELECT Esta_Id, Esta_Descripcion, Esta_UsuarioCreacion, Esta_FechaCreacion, Esta_UsuarioModificacion, Esta_FechaModificacion
    FROM Grl.tbEstados
END;
GO
/****** Object:  StoredProcedure [Grl].[SP_EstadosCiviles_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------

CREATE PROCEDURE [Grl].[SP_EstadosCiviles_Actualizar]
    @Estc_Id INT,
    @Estc_Descripcion VARCHAR(30),
    @Estc_UsuarioModificacion INT,
    @Estc_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        UPDATE Grl.tbEstadosCiviles
        SET Estc_Descripcion = @Estc_Descripcion,
            Estc_UsuarioModificacion = @Estc_UsuarioModificacion,
            Estc_FechaModificacion = @Estc_FechaModificacion
        WHERE Estc_Id = @Estc_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_EstadosCiviles_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_EstadosCiviles_Eliminar]
    @Estc_Id INT
AS
BEGIN
    BEGIN TRY
        UPDATE Grl.tbEstadosCiviles
        SET Estc_Estado = 0
        WHERE Estc_Id = @Estc_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_EstadosCiviles_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_EstadosCiviles_Insertar]
    @Estc_Descripcion VARCHAR(30),
    @Estc_UsuarioCreacion INT,
    @Estc_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        INSERT INTO Grl.tbEstadosCiviles (
            Estc_Descripcion,
            Estc_UsuarioCreacion,
            Estc_FechaCreacion
        )
        VALUES (
            @Estc_Descripcion,
            @Estc_UsuarioCreacion,
            @Estc_FechaCreacion
        );
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_EstadosCiviles_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_EstadosCiviles_LlenarEditar]
	@Estc_Id INT
AS
BEGIN
    SELECT *,
	 CASE WHEN Estc_UsuarioCreacion = Usua_Id THEN usu.Usua_Usuario ELSE usu.Usua_Usuario END AS UsuarioCreacion,
	CASE WHEN Estc_UsuarioModificacion = Usua_Id THEN usu.Usua_Usuario ELSE 'Sin Modificar' END AS UsuarioModificacion
    FROM Grl.tbEstadosCiviles esta	inner join Acc.tbUsuarios usu on usu.Usua_UsuarioCreacion = esta.Estc_UsuarioCreacion
    WHERE Estc_Id = @Estc_Id
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_EstadosCiviles_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Grl].[SP_EstadosCiviles_Seleccionar]
AS
BEGIN
    SELECT Estc_Id, Estc_Descripcion, Estc_UsuarioCreacion, Estc_FechaCreacion, Estc_UsuarioModificacion, Estc_FechaModificacion, Estc_Estado
    FROM Grl.tbEstadosCiviles
    WHERE Estc_Estado = 1;
END;

GO
/****** Object:  StoredProcedure [Grl].[SP_ObtenerEmpleado_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Grl].[SP_ObtenerEmpleado_Seleccionar]
    @Empl_DNI VARCHAR(50)
AS
BEGIN
    SELECT CONCAT(Empl_Nombre, ' ', Empl_Apellido) Empl_Nombre, Empl_DNI, Empl_Id
    FROM Grl.tbEmpleados
    WHERE Empl_DNI = @Empl_DNI
END;
GO
/****** Object:  StoredProcedure [Pro].[ObtenerCursosPorMes]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Pro].[ObtenerCursosPorMes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        YEAR(CurIm_FechaInicio) AS Year,
        MONTH(CurIm_FechaInicio) AS Month,
        COUNT(*) AS TotalCursos
    FROM
        Pro.tbCursosImpartidos
    GROUP BY
        YEAR(CurIm_FechaInicio),
        MONTH(CurIm_FechaInicio)
END
GO
/****** Object:  StoredProcedure [Pro].[SP_Cargos_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [Pro].[SP_Cargos_Actualizar]
@Carg_Id int,
@Carg_Descripcion varchar(60),
@Carg_UsuarioModificacion int,
@Carg_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        UPDATE [Pro].[tbCargos]
        SET Carg_Descripcion = @Carg_Descripcion,
            Carg_UsuarioModificacion = @Carg_UsuarioModificacion,
            Carg_FechaModificacion = @Carg_FechaModificacion
        WHERE Carg_Id = @Carg_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Pro].[SP_Cargos_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [Pro].[SP_Cargos_Eliminar]
@Carg_Id int
AS
BEGIN
    BEGIN TRY
        Update [Pro].[tbCargos]
		set Carg_Estado = 0
        WHERE Carg_Id = @Carg_Id;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Pro].[SP_Cargos_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE  [Pro].[SP_Cargos_Insertar]
@Carg_Descripcion varchar(60),
@Carg_UsuarioCreacion int,
@Carg_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Pro].[tbCargos] (
			Carg_Descripcion,
			[Carg_UsuarioCreacion],
			[Carg_FechaCreacion]
        )
        VALUES (
            @Carg_Descripcion,
            @Carg_UsuarioCreacion,
            @Carg_FechaCreacion
        );
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [Pro].[SP_Cargos_LlenarEditar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [Pro].[SP_Cargos_LlenarEditar] 
@Carg_Id int
AS
BEGIN
    SELECT 
	[Carg_Id], [Carg_Descripcion], [Carg_UsuarioCreacion], [Carg_FechaCreacion], [Carg_UsuarioModificacion], [Carg_FechaModificacion],
	 USU.Usua_Usuario AS UsuarioCreacion,
	 usua.Usua_Usuario AS UsuarioModificacion
    FROM[Pro].[tbCargos] carg left join Acc.tbUsuarios usu on carg.Carg_UsuarioCreacion = usu.Usua_Id 
	left join Acc.tbUsuarios usua on carg.Carg_UsuarioModificacion = usua.Usua_Id 
    WHERE Carg_Id = @Carg_Id and Carg_Estado = 1
END;

GO
/****** Object:  StoredProcedure [Pro].[SP_Cargos_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   procedure [Pro].[SP_Cargos_Seleccionar]
AS
BEGIN
	SELECT 
	Carg_Id,
	Carg_Descripcion
	FROM Pro.tbCargos
	where Carg_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Categoria_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Categoria_Actualizar]
    @Cate_Id int,
    @Cate_Descripcion varchar(60),
    @Cate_Imagen varchar(max),
    @Cate_UsuarioModificacion int,
    @Cate_FechaModificacion datetime
AS
BEGIN
begin try
    UPDATE [Pro].[tbCategorias]
    SET Cate_Descripcion = @Cate_Descripcion,
        Cate_Imagen = @Cate_Imagen,
        Cate_UsuarioModificacion = @Cate_UsuarioModificacion,
        Cate_FechaModificacion = @Cate_FechaModificacion
    WHERE Cate_Id = @Cate_Id
	select 1;
	end try
	begin catch
		select 0;
	end catch
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Categoria_Buscar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_Categoria_Buscar]
    @Cate_Id int
AS
BEGIN
	Select 
	[Cate_Id],
	[Cate_Descripcion],
	[Cate_Imagen],
	U1.Usua_Usuario as creacion,
	Cate_FechaCreacion,
	U2.Usua_Usuario as modificacion,
	Cate_FechaModificacion
	from [Pro].[tbCategorias] CA left join [Acc].[tbUsuarios] U1
	on U1.Usua_Id = CA.Cate_UsuarioCreacion left join [Acc].[tbUsuarios] U2
	On U2.Usua_Id = CA.Cate_UsuarioModificacion
	where Cate_Id = @Cate_Id and Cate_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Categoria_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Categoria_Eliminar]
    @Cate_Id int
AS
BEGIN
begin try
    UPDATE[Pro].[tbCategorias]
	set Cate_Estado = 0
    WHERE Cate_Id = @Cate_Id
	select 1;
	end try
	begin catch
	select 0;
	end catch
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Categoria_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_Categoria_Insertar]
    @Cate_Descripcion varchar(60),
    @Cate_Imagen varchar(max),
    @Cate_UsuarioCreacion int,
    @Cate_FechaCreacion datetime
AS
BEGIN
 BEGIN TRY
    INSERT INTO [Pro].[tbCategorias] (Cate_Descripcion, Cate_Imagen, Cate_UsuarioCreacion, Cate_FechaCreacion)
    VALUES (@Cate_Descripcion, @Cate_Imagen, @Cate_UsuarioCreacion, @Cate_FechaCreacion)
        SELECT 1;
	end try
	begin catch
        SELECT 0;
	end catch
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Categoria_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   PROCEDURE [Pro].[SP_Categoria_Seleccionar]
AS
BEGIN
	Select 
	[Cate_Id],
	[Cate_Descripcion],
	[Cate_Imagen]
	from [Pro].[tbCategorias]
	where Cate_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Contenido_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_Contenido_Actualizar]
    @Cont_Id int,
    @Cont_Descripcion varchar(60),
    @Cont_DuracionHoras int,
    @Cont_UsuarioModificacion int,
    @Cont_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        UPDATE [Pro].[tbContenido]
        SET Cont_Descripcion = @Cont_Descripcion,
            Cont_DuracionHoras = @Cont_DuracionHoras,
            Cont_UsuarioModificacion = @Cont_UsuarioModificacion,
            Cont_FechaModificacion = @Cont_FechaModificacion
        WHERE Cont_Id = @Cont_Id
		select 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Contenido_Buscar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [Pro].[SP_Contenido_Buscar]
@Cont_Id int
AS
BEGIN
        SELECT 
		[Cont_Id],
		[Cont_Descripcion],
		[Cont_DuracionHoras],
		U1.Usua_Usuario as UsuarioCreacion,
		U2.Usua_Usuario as UsuarioModificacion,
		Cont_FechaCreacion,
		Cont_FechaModificacion
        FROM [Pro].[tbContenido] CO left join [Acc].[tbUsuarios] U1
	on U1.Usua_Id = CO.Cont_UsuarioCreacion left join [Acc].[tbUsuarios] U2
	On U2.Usua_Id = CO.Cont_UsuarioModificacion
		where Cont_Id = @Cont_Id and Cont_Estado = 1
   
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Contenido_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   PROCEDURE [Pro].[SP_Contenido_Eliminar]
    @Cont_Id int
AS
BEGIN
    BEGIN TRY
        Update [Pro].[tbContenido]
		set 
		Cont_Estado = 0
        WHERE Cont_Id = @Cont_Id
		select 1;
    END TRY
    BEGIN CATCH
        
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Contenido_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Contenido_Insertar]
    @Cont_Descripcion varchar(60),
    @Cont_DuracionHoras int,
    @Cont_UsuarioCreacion int,
    @Cont_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Pro].[tbContenido] (Cont_Descripcion, Cont_DuracionHoras, Cont_UsuarioCreacion, Cont_FechaCreacion)
        VALUES (@Cont_Descripcion, @Cont_DuracionHoras, @Cont_UsuarioCreacion, @Cont_FechaCreacion)
		select 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Contenido_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_Contenido_Seleccionar]
AS
BEGIN
        SELECT 
		[Cont_Id],
		[Cont_Descripcion],
		[Cont_DuracionHoras]
        FROM [Pro].[tbContenido]
		where Cont_Estado = 1
   
END

GO
/****** Object:  StoredProcedure [Pro].[SP_ContenidoPorCurso_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_ContenidoPorCurso_Actualizar]
    @ConPc_Id int,
    @Cont_Id int,
    @Curso_Id int,
    @ConPc_UsuarioModificacion int,
    @ConPc_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        UPDATE [Pro].[tbContenidoPorCurso]
        SET Cont_Id = @Cont_Id,
            Curso_Id = @Curso_Id,
            ConPc_UsuarioModificacion = @ConPc_UsuarioModificacion,
            ConPc_FechaModificacion = @ConPc_FechaModificacion
        WHERE ConPc_Id = @ConPc_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_ContenidoPorCurso_Buscar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [Pro].[SP_ContenidoPorCurso_Buscar]
@ConPc_Id int
AS
BEGIN
        SELECT 
		[ConPc_Id],
		CO.[Cont_Id],
		CO.[Curso_Id],
		U1.Usua_Usuario as creacion,
		U2.Usua_Usuario as modificacion,
		ConPc_FechaCreacion,
		ConPc_FechaModificacion,
		C.Cont_Descripcion as Cont_Descripcion,
		Cu.Curso_Descripcion as Curso_Descripcion,
		Cu.Curso_DuracionHoras as Curso_DuracionHoras,
		Cu.Curso_Descripcion,
		Cu.Curso_Imagen,
		CA.Cate_Descripcion
        FROM [Pro].[tbContenidoPorCurso] CO left join [Acc].[tbUsuarios] U1
	on U1.Usua_Id = CO.ConPc_UsuarioCreacion left join [Acc].[tbUsuarios] U2
	On U2.Usua_Id = CO.ConPc_UsuarioModificacion  left join [Pro].[tbContenido] C
		On CO.Cont_Id = C.Cont_Id left join [Pro].[tbCursos] Cu
		On Cu.Curso_Id = CO.Curso_Id inner join Pro.tbCategorias CA on CA.Cate_Id = Cu.Cate_Id
		where ConPc_Id = @ConPc_Id and ConPc_Estado = 1
  
END

GO
/****** Object:  StoredProcedure [Pro].[SP_ContenidoPorCurso_BuscarContenido]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   procedure [Pro].[SP_ContenidoPorCurso_BuscarContenido] 
@Cont_Descripcion varchar(60)
AS
begin 
	select
	[Cont_Id],
	[Cont_Descripcion],
	[Cont_DuracionHoras]
	from [Pro].[tbContenido]
	where [Cont_Descripcion] = @Cont_Descripcion
end 
GO
/****** Object:  StoredProcedure [Pro].[SP_ContenidoPorCurso_BuscarCurso]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [Pro].[SP_ContenidoPorCurso_BuscarCurso] 
@Curso_Descripcion VARCHAR(60)
AS
BEGIN

        SELECT 
		C.Curso_Id,
		C.Curso_DuracionHoras,
		C.Curso_Descripcion,
		C.Curso_Imagen,
		CA.Cate_Descripcion

		FROM  Pro.tbCursos C inner join Pro.tbCategorias CA on CA.Cate_Id = C.Cate_Id
		where Curso_Descripcion = @Curso_Descripcion and Curso_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_ContenidoPorCurso_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_ContenidoPorCurso_Eliminar]
    @ConPc_Id int
AS
BEGIN
    BEGIN TRY
        Update [Pro].[tbContenidoPorCurso]
		set ConPc_Estado = 0
        WHERE ConPc_Id = @ConPc_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_ContenidoPorCurso_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_ContenidoPorCurso_Insertar]
    @Cont_Id int,
    @Curso_Id int,
    @ConPc_UsuarioCreacion int,
    @ConPc_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Pro].[tbContenidoPorCurso] (Cont_Id, Curso_Id, ConPc_UsuarioCreacion, ConPc_FechaCreacion)
        VALUES (@Cont_Id, @Curso_Id, @ConPc_UsuarioCreacion, @ConPc_FechaCreacion)
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_ContenidoPorCurso_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_ContenidoPorCurso_Seleccionar]
AS
BEGIN
        SELECT 
		[ConPc_Id],
		C.Cont_Descripcion as Cont_Descripcion,
		Cu.Curso_Descripcion as Curso_Descripcion,
		Cu.Curso_DuracionHoras as Curso_DuracionHoras,
		Cu.Curso_Descripcion,
		Cu.Curso_Imagen,
		CA.Cate_Descripcion
        FROM [Pro].[tbContenidoPorCurso] CC left join [Pro].[tbContenido] C
		On CC.Cont_Id = C.Cont_Id left join [Pro].[tbCursos] Cu
		On Cu.Curso_Id = CC.Curso_Id inner join Pro.tbCategorias CA on CA.Cate_Id = Cu.Cate_Id
		where ConPc_Estado = 1
  
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Curso_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Curso_Actualizar]
    @Curso_Id int,
    @Curso_Descripcion varchar(60),
    @Curso_DuracionHoras int,
    @Curso_Imagen varchar(MAX),
    @Cate_Id int,
    @Curso_UsuarioModificacion int,
    @Curso_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        UPDATE [Pro].[tbCursos]
        SET Curso_Descripcion = @Curso_Descripcion,
            Curso_DuracionHoras = @Curso_DuracionHoras,
            Curso_Imagen = @Curso_Imagen,
            Cate_Id = @Cate_Id,
            Curso_UsuarioModificacion = @Curso_UsuarioModificacion,
            Curso_FechaModificacion = @Curso_FechaModificacion
        WHERE Curso_Id = @Curso_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Curso_Buscar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_Curso_Buscar]
@Curso_Id int
AS
BEGIN
        SELECT 
		[Curso_Id],
		[Curso_Descripcion], 
		[Curso_DuracionHoras],
		[Curso_Imagen],
		CU.[Cate_Id],
		U1.Usua_Usuario as creacion,
		U2.Usua_Usuario as modificacion,
		Curso_FechaCreacion,
		Curso_FechaModificacion,
		Cate_Descripcion as Categoria

        FROM [Pro].[tbCursos] CU left join [Acc].[tbUsuarios] U1
	on U1.Usua_Id = CU.Curso_UsuarioCreacion left join [Acc].[tbUsuarios] U2
	On U2.Usua_Id = CU.Curso_UsuarioModificacion left join [Pro].[tbCategorias] Ca
		On CU.Cate_Id = Ca.Cate_Id
		where Curso_Id = @Curso_Id and Curso_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Curso_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Curso_Eliminar]
    @Curso_Id int
AS
BEGIN
    BEGIN TRY
        update [Pro].[tbCursos]
		set Curso_Estado = 0
        WHERE Curso_Id = @Curso_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Curso_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Curso_Insertar]
    @Curso_Descripcion varchar(60),
    @Curso_DuracionHoras int,
    @Curso_Imagen varchar(MAX),
    @Cate_Id int,
    @Curso_UsuarioCreacion int,
    @Curso_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Pro].[tbCursos] (Curso_Descripcion, Curso_DuracionHoras, Curso_Imagen, Cate_Id, Curso_UsuarioCreacion, Curso_FechaCreacion)
        VALUES (@Curso_Descripcion, @Curso_DuracionHoras, @Curso_Imagen, @Cate_Id, @Curso_UsuarioCreacion, @Curso_FechaCreacion)
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Curso_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_Curso_Seleccionar]
AS
BEGIN
        SELECT 
		[Curso_Id],
		[Curso_Descripcion], 
		[Curso_DuracionHoras],
		[Curso_Imagen],
		Cate_Descripcion as Categoria
        FROM [Pro].[tbCursos] Cu left join [Pro].[tbCategorias] Ca
		On Cu.Cate_Id = Ca.Cate_Id
		where Curso_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_CursoImpartido_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_CursoImpartido_Actualizar]
    @CurIm_Id int,
    @Curso_Id int,
    @Empl_Id int,
    @CurIm_FechaInicio datetime,
    @CurIm_FechaFin datetime,
    @CurIm_UsuarioFinalizacion int,
    @CurIm_Finalizar bit,
    @CurIm_UsuarioModificacion int,
    @CurIm_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        UPDATE [Pro].[tbCursosImpartidos]
        SET Curso_Id = @Curso_Id,
            Empl_Id = @Empl_Id,
            CurIm_FechaInicio = @CurIm_FechaInicio,
            CurIm_FechaFin = @CurIm_FechaFin,
            CurIm_UsuarioFinalizacion = @CurIm_UsuarioFinalizacion,
            CurIm_Finalizar = @CurIm_Finalizar,
            CurIm_UsuarioModificacion = @CurIm_UsuarioModificacion,
            CurIm_FechaModificacion = @CurIm_FechaModificacion
        WHERE CurIm_Id = @CurIm_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_CursoImpartido_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_CursoImpartido_Eliminar]
    @CurIm_Id int
AS
BEGIN
    BEGIN TRY
        DELETE FROM [Pro].[tbCursosImpartidos]
        WHERE CurIm_Id = @CurIm_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_CursoImpartido_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_CursoImpartido_Insertar]
    @Curso_Id int,
    @Empl_Id int,
    @CurIm_FechaInicio datetime,
    @CurIm_FechaFin datetime,
    @CurIm_UsuarioCreacion int,
    @CurIm_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Pro].[tbCursosImpartidos] (Curso_Id, Empl_Id, CurIm_FechaInicio, CurIm_FechaFin, CurIm_UsuarioCreacion, CurIm_FechaCreacion)
        VALUES (@Curso_Id, @Empl_Id, @CurIm_FechaInicio, @CurIm_FechaFin, @CurIm_UsuarioCreacion, @CurIm_FechaCreacion)
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_CursosImpartidos_Buscar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_CursosImpartidos_Buscar] 
@CurIm_Id int
AS
BEGIN

        SELECT 
		[CurIm_Id],
		CI.[Curso_Id],
		C.Curso_Descripcion as Cursos,
		CI.[Empl_Id],
		Empl_Nombre + ' ' + Empl_Apellido as Nombre,
		[CurIm_FechaInicio],
		[CurIm_FechaFin],
		[CurIm_UsuarioFinalizacion],
		[CurIm_Finalizar],
        U1.Usua_Usuario as Creacion,
		CurIm_FechaCreacion,
		U2.Usua_Usuario as Modificacion,
		CurIm_FechaModificacion
		FROM [Pro].[tbCursosImpartidos] CI left join [Acc].[tbUsuarios] U1
	on U1.Usua_Id = CI.CurIm_UsuarioCreacion left join [Acc].[tbUsuarios] U2
	on U2.Usua_Id = CI.CurIm_UsuarioModificacion left join [Pro].[tbCursos] C
	on C.Curso_Id = CI.Curso_Id left join [Grl].[tbEmpleados] E
	on E.Empl_Id = CI.Empl_Id
		where CurIm_Id = @CurIm_Id and CurIm_Estado = 1
   
END

GO
/****** Object:  StoredProcedure [Pro].[SP_CursosImpartidos_BuscarCurso]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [Pro].[SP_CursosImpartidos_BuscarCurso] 
@Curso_Descripcion VARCHAR(60)
AS
BEGIN

        SELECT 
		C.Curso_Id,
		C.Curso_DuracionHoras,
		C.Curso_Descripcion,
		C.Curso_Imagen,
		CA.Cate_Descripcion

		FROM  Pro.tbCursos C inner join Pro.tbCategorias CA on CA.Cate_Id = C.Cate_Id
		where Curso_Descripcion = @Curso_Descripcion and Curso_Estado = 1
END
GO
/****** Object:  StoredProcedure [Pro].[SP_CursosImpartidos_BuscarEmpleado]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [Pro].[SP_CursosImpartidos_BuscarEmpleado]
@Empl_DNI VARCHAR(13)
AS
BEGIN

        SELECT
		Empl_Id,
		CONCAT(Empl_Nombre, ' ' , Empl_Apellido) Empl_Nombre
		FROM [Grl].[tbEmpleados]
		where Empl_DNI = @Empl_DNI and Empl_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_CursosImpartidos_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Pro].[SP_CursosImpartidos_Seleccionar]
AS
BEGIN

        SELECT 
		[CurIm_Id],
		Curso_Descripcion as Cursos,
		Empl_Nombre + ' ' + Empl_Apellido AS Nombre ,
		[CurIm_FechaInicio],
		[CurIm_FechaFin],
		[CurIm_UsuarioFinalizacion],
		[CurIm_Finalizar],
		(C.Curso_Id * E.Empl_SalarioHora) PagoEmpleado
        FROM [Pro].[tbCursosImpartidos] CP left join [Pro].[tbCursos] C
		On CP.Curso_Id = C.Curso_Id left join [Grl].[tbEmpleados] E
		On E.Empl_Id = CP.Empl_Id
		where CurIm_Estado = 1
   
END
GO
/****** Object:  StoredProcedure [Pro].[SP_InformeEmpleado_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_InformeEmpleado_Actualizar]
    @InfoE_Id int,
    @InfoE_Calificacion int,
    @Empl_Id int,
    @Curso_Id int,
    @InfoE_Observaciones varchar(max),
    @InfoE_UsuarioModificacion int,
    @InfoE_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        UPDATE [Pro].[tbInformeEmpleados]
        SET InfoE_Calificacion = @InfoE_Calificacion,
            Empl_Id = @Empl_Id,
            Curso_Id = @Curso_Id,
            InfoE_Observaciones = @InfoE_Observaciones,
            InfoE_UsuarioModificacion = @InfoE_UsuarioModificacion,
            InfoE_FechaModificacion = @InfoE_FechaModificacion
        WHERE InfoE_Id = @InfoE_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_InformeEmpleado_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_InformeEmpleado_Eliminar]
    @InfoE_Id int
AS
BEGIN
    BEGIN TRY
        DELETE FROM [Pro].[tbInformeEmpleados]
        WHERE InfoE_Id = @InfoE_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_InformeEmpleado_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_InformeEmpleado_Insertar]
    @InfoE_Calificacion int,
    @Empl_Id int,
    @Curso_Id int,
    @InfoE_Observaciones varchar(max),
    @InfoE_UsuarioCreacion int,
    @InfoE_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Pro].[tbInformeEmpleados] (InfoE_Calificacion, Empl_Id, Curso_Id, InfoE_Observaciones, InfoE_UsuarioCreacion, InfoE_FechaCreacion)
        VALUES (@InfoE_Calificacion, @Empl_Id, @Curso_Id, @InfoE_Observaciones, @InfoE_UsuarioCreacion, @InfoE_FechaCreacion)
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_InformeEmpleados_Buscar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_InformeEmpleados_Buscar]
@InforE_Id int
AS
BEGIN
        SELECT 
		[InfoE_Id],
		[InfoE_Calificacion],
		EM.[Empl_Id],
		EM.[Curso_Id],
		[InfoE_Observaciones],
		U1.Usua_Usuario as creacion,
		U2.Usua_Usuario as modificacion,
		InfoE_FechaCreacion,
		InfoE_FechaModificacion,
		Empl_Nombre + ' '+ Empl_Apellido AS nombre,
		Curso_Descripcion as Cursos 
        FROM [Pro].[tbInformeEmpleados] EM left join [Acc].[tbUsuarios] U1
	on U1.Usua_Id = EM.InfoE_UsuarioCreacion left join [Acc].[tbUsuarios] U2
	On U2.Usua_Id = EM.InfoE_UsuarioModificacion left join [Grl].[tbEmpleados] E
		On E.Empl_Id = EM.Empl_Id left join [Pro].[tbCursos] C
		ON C.Curso_Id = EM.Curso_Id
		where InfoE_Id = @InforE_Id
END

GO
/****** Object:  StoredProcedure [Pro].[SP_InformeEmpleados_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_InformeEmpleados_Seleccionar]
AS
BEGIN
        SELECT 
		[InfoE_Id],
		[InfoE_Calificacion],
		Empl_Nombre + Empl_Apellido AS Nombre,
		Curso_Descripcion as Cursos ,
		[InfoE_Observaciones]
        FROM [Pro].[tbInformeEmpleados] IE left join [Grl].[tbEmpleados] E
		On E.Empl_Id = IE.Empl_Id left join [Pro].[tbCursos] C
		ON C.Curso_Id = IE.Curso_Id
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Titulo_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Titulo_Actualizar]
    @Titl_Id int,
    @Titl_Descripcion varchar(60),
    @Titl_ValorMonetario numeric(8,2),
    @Titl_UsuarioModificacion int,
    @Titl_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        UPDATE [Pro].[tbTitulos]
        SET Titl_Descripcion = @Titl_Descripcion,
            Titl_ValorMonetario = @Titl_ValorMonetario,
            Titl_UsuarioModificacion = @Titl_UsuarioModificacion,
            Titl_FechaModificacion = @Titl_FechaModificacion
        WHERE Titl_Id = @Titl_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Titulo_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Titulo_Eliminar]
    @Titl_Id int
AS
BEGIN
    BEGIN TRY
        Update [Pro].[tbTitulos]
		set Titl_Estado = 0
        WHERE Titl_Id = @Titl_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Pro].[SP_Titulo_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Titulo_Insertar]
    @Titl_Descripcion varchar(60),
    @Titl_ValorMonetario numeric(8,2),
    @Titl_UsuarioCreacion int,
    @Titl_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Pro].[tbTitulos] (Titl_Descripcion, Titl_ValorMonetario, Titl_UsuarioCreacion, Titl_FechaCreacion)
        VALUES (@Titl_Descripcion, @Titl_ValorMonetario, @Titl_UsuarioCreacion, @Titl_FechaCreacion)
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_TituloPorEmpleado_Actualizar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_TituloPorEmpleado_Actualizar]
    @TitPe_Id int,
    @Titl_Id int,
    @Empl_Id int,
    @TitPe_UsuarioModificacion int,
    @TitPe_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        UPDATE [Pro].[tbTitulosPorEmpleado]
        SET Titl_Id = @Titl_Id,
            Empl_Id = @Empl_Id,
            TitPe_UsuarioModificacion = @TitPe_UsuarioModificacion,
            TitPe_FechaModificacion = @TitPe_FechaModificacion
        WHERE TitPe_Id = @TitPe_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_TituloPorEmpleado_Eliminar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_TituloPorEmpleado_Eliminar]
    @TitPe_Id int
AS
BEGIN
    BEGIN TRY
        Update [Pro].[tbTitulosPorEmpleado]
		set TitPe_Estado = 0
        WHERE TitPe_Id = @TitPe_Id
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END
GO
/****** Object:  StoredProcedure [Pro].[SP_TituloPorEmpleado_Insertar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_TituloPorEmpleado_Insertar]
    @Titl_Id int,
    @Empl_Id int,
    @TitPe_UsuarioCreacion int,
    @TitPe_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        INSERT INTO [Pro].[tbTitulosPorEmpleado] (Titl_Id, Empl_Id, TitPe_UsuarioCreacion, TitPe_FechaCreacion)
        VALUES (@Titl_Id, @Empl_Id, @TitPe_UsuarioCreacion, @TitPe_FechaCreacion)
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Titulos_Buscar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_Titulos_Buscar]
@Titl_Id int
AS
BEGIN
        SELECT 
		[Titl_Id],
		[Titl_Descripcion],
		[Titl_ValorMonetario],		
		U1.Usua_Usuario as UsuarioCreacion,
		U2.Usua_Usuario as UsuarioModificacion,
		Titl_FechaCreacion,
		Titl_FechaModificacion
        FROM [Pro].[tbTitulos] T join [Acc].[tbUsuarios] U1
	on U1.Usua_Id = T.Titl_UsuarioCreacion left join [Acc].[tbUsuarios] U2
	On U2.Usua_Id = T.Titl_UsuarioModificacion
		where Titl_Id = @Titl_Id and Titl_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_Titulos_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_Titulos_Seleccionar]
AS
BEGIN
        SELECT 
		[Titl_Id],
		[Titl_Descripcion],
		[Titl_ValorMonetario]
        FROM [Pro].[tbTitulos]
		where Titl_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_TitulosPorEmpleado_Buscar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [Pro].[SP_TitulosPorEmpleado_Buscar]
@TitPe_Id int
AS
BEGIN
        SELECT 
		[TitPe_Id],
		[Titl_Id],
		T.[Empl_Id],		
		U1.Usua_Usuario as creacion,
		U2.Usua_Usuario as modificacion,
		TitPe_FechaCreacion,
		TitPe_FechaModificacion
        FROM [Pro].[tbTitulosPorEmpleado] T join [Acc].[tbUsuarios] U1
	on U1.Usua_Id = T.TitPe_UsuarioCreacion left join [Acc].[tbUsuarios] U2
	On U2.Usua_Id = T.TitPe_UsuarioModificacion
		where TitPe_Id = @TitPe_Id and TitPe_Estado = 1
END

GO
/****** Object:  StoredProcedure [Pro].[SP_TitulosPorEmpleado_Seleccionar]    Script Date: 8/5/2024 11:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Pro].[SP_TitulosPorEmpleado_Seleccionar]
AS
BEGIN
        SELECT 
		[TitPe_Id],
		Titl_Descripcion as Titulo,
		Empl_Nombre + ' ' + Empl_Apellido as Empleado
        FROM [Pro].[tbTitulosPorEmpleado] TE left join [Pro].[tbTitulos] T
		On T.Titl_Id = TE.Titl_Id left join [Grl].[tbEmpleados] E
		ON E.Empl_Id = TE.Empl_Id
		where TitPe_Estado = 1
END

GO
