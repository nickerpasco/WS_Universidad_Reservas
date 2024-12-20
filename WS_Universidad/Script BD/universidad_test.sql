USE [db_aaf83c_universidadtest]
GO
/****** Object:  Table [dbo].[Alquileres]    Script Date: 19/11/2024 09:21:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquileres](
	[AlquilerID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[CanchaID] [int] NOT NULL,
	[FechaAlquiler] [datetime] NOT NULL,
	[DuracionHoras] [int] NOT NULL,
	[MontoTotal] [decimal](10, 2) NOT NULL,
	[Estado] [nvarchar](50) NULL,
	[CodigoAlquiler] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AlquilerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 19/11/2024 09:21:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[AlumnoID] [int] IDENTITY(1,1) NOT NULL,
	[CodigoAlumno] [nvarchar](100) NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AlumnoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Canchas]    Script Date: 19/11/2024 09:21:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canchas](
	[CanchaID] [int] IDENTITY(1,1) NOT NULL,
	[ProveedorID] [int] NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Deporte] [nvarchar](50) NULL,
	[Direccion] [nvarchar](255) NULL,
	[PrecioPorHora] [decimal](10, 2) NULL,
	[Disponible] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CanchaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HorariosCancha]    Script Date: 19/11/2024 09:21:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorariosCancha](
	[HorarioID] [int] IDENTITY(1,1) NOT NULL,
	[CanchaID] [int] NOT NULL,
	[DiaSemana] [nvarchar](10) NULL,
	[HoraInicio] [time](7) NOT NULL,
	[HoraFin] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HorarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 19/11/2024 09:21:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[PagoID] [int] IDENTITY(1,1) NOT NULL,
	[AlquilerID] [int] NOT NULL,
	[Monto] [decimal](10, 2) NOT NULL,
	[TipoPago] [nvarchar](50) NULL,
	[Estado] [nvarchar](50) NULL,
	[FechaPago] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 19/11/2024 09:21:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[ProveedorID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[Empresa] [nvarchar](100) NULL,
	[Telefono] [nvarchar](15) NULL,
	[Direccion] [nvarchar](255) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaCancha]    Script Date: 19/11/2024 09:21:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaCancha](
	[ReservaID] [int] IDENTITY(1,1) NOT NULL,
	[AlumnoID] [int] NULL,
	[FechaReserva] [date] NULL,
	[HoraInicio] [time](7) NULL,
	[HoraFin] [time](7) NULL,
	[Cancha] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservaCanchas]    Script Date: 19/11/2024 09:21:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservaCanchas](
	[ReservaID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NOT NULL,
	[CanchaID] [int] NOT NULL,
	[FechaReserva] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 19/11/2024 09:21:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Contraseña] [nvarchar](255) NOT NULL,
	[Perfil] [nvarchar](50) NOT NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alquileres] ON 

INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (4, 15, 2, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'e38bb7c0-7c6a-4c42-bdbb-cff6da406a6c')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (5, 21, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'c54593bb-8a15-40d6-a6a1-783fa814359a')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (6, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'aec46db1-0b31-4f52-90e8-292efca284b2')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (7, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'8765cc10-ed70-4891-94ec-f1c7b02cd026')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (8, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'4c7cbd78-0dfb-4ea8-b8ce-9234db1489ae')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (9, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'af817d90-636b-4af5-9697-72266ad15059')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (10, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'75fdc855-5663-4b15-8564-f24919d0806d')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (11, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'2ec4285d-419b-45c1-8724-20ba63d250bd')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (12, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'9120c550-f6f5-4103-b289-7c1ed881f445')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (13, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'59fdf70f-99ea-4816-bdc6-b576fa2e82ed')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (14, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'c89421e0-0723-4665-8f2e-33360ac055aa')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (15, 15, 2, CAST(N'2024-11-20T19:00:00.000' AS DateTime), 100, CAST(2.00 AS Decimal(10, 2)), N'A', N'aa076aeb-e4a8-45ef-a836-bc1a930a8dfe')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (16, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'1c04dae4-d987-4803-a675-75758531132e')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (17, 15, 7, CAST(N'2023-09-09T00:00:00.000' AS DateTime), 2, CAST(200.00 AS Decimal(10, 2)), N'A', N'91c75be5-7bbd-47e8-88a4-749885852945')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (18, 15, 2, CAST(N'2024-11-19T19:08:00.000' AS DateTime), 100, CAST(2.00 AS Decimal(10, 2)), N'A', N'246b6b2d-a516-4d1a-8029-9d0d21cab015')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (19, 22, 6, CAST(N'2024-11-30T20:30:00.000' AS DateTime), 100, CAST(1.00 AS Decimal(10, 2)), N'A', N'771d0b86-43b6-4401-9596-0ebb7b409e4e')
INSERT [dbo].[Alquileres] ([AlquilerID], [UsuarioID], [CanchaID], [FechaAlquiler], [DuracionHoras], [MontoTotal], [Estado], [CodigoAlquiler]) VALUES (20, 15, 10, CAST(N'2024-11-20T22:30:00.000' AS DateTime), 100, CAST(1.00 AS Decimal(10, 2)), N'A', N'0dca4f63-5308-4c97-8a2e-5ce1d6bed966')
SET IDENTITY_INSERT [dbo].[Alquileres] OFF
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([AlumnoID], [CodigoAlumno], [Nombre], [Apellido], [Email]) VALUES (1, NULL, N'Nicker', N'Pasco', N'correitogmail.comn')
INSERT [dbo].[Alumno] ([AlumnoID], [CodigoAlumno], [Nombre], [Apellido], [Email]) VALUES (2, N'CO011', N'Jose Jose ', N'Vilca Vilca', N'correitogmail.comn')
INSERT [dbo].[Alumno] ([AlumnoID], [CodigoAlumno], [Nombre], [Apellido], [Email]) VALUES (3, NULL, N'Anderson ', N'Cajas', N'correitogmail.comn')
INSERT [dbo].[Alumno] ([AlumnoID], [CodigoAlumno], [Nombre], [Apellido], [Email]) VALUES (4, NULL, N'Fabrizio ', N'Calderon', N'correitogmail.comn')
INSERT [dbo].[Alumno] ([AlumnoID], [CodigoAlumno], [Nombre], [Apellido], [Email]) VALUES (7, N'CO011', N'Fabrizio ', N'Calderon', N'correitogmail.comn')
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Canchas] ON 

INSERT [dbo].[Canchas] ([CanchaID], [ProveedorID], [Nombre], [Deporte], [Direccion], [PrecioPorHora], [Disponible]) VALUES (2, 7, N'Cancha 1222', N'Fútbol', NULL, CAST(100.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Canchas] ([CanchaID], [ProveedorID], [Nombre], [Deporte], [Direccion], [PrecioPorHora], [Disponible]) VALUES (5, 7, N'Cancha 1222', N'Fútbol', NULL, CAST(100.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Canchas] ([CanchaID], [ProveedorID], [Nombre], [Deporte], [Direccion], [PrecioPorHora], [Disponible]) VALUES (6, 7, N'Cancha 1', N'Volley', NULL, CAST(23.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Canchas] ([CanchaID], [ProveedorID], [Nombre], [Deporte], [Direccion], [PrecioPorHora], [Disponible]) VALUES (7, 11, N'Cancha Fubol', N'Basket', NULL, CAST(120.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Canchas] ([CanchaID], [ProveedorID], [Nombre], [Deporte], [Direccion], [PrecioPorHora], [Disponible]) VALUES (8, 12, N'Cancha Futbol', N'Futbol', NULL, CAST(1200.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Canchas] ([CanchaID], [ProveedorID], [Nombre], [Deporte], [Direccion], [PrecioPorHora], [Disponible]) VALUES (10, 9, N'Bombonera', N'futbol', NULL, CAST(100.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Canchas] ([CanchaID], [ProveedorID], [Nombre], [Deporte], [Direccion], [PrecioPorHora], [Disponible]) VALUES (11, 10, N'Camp nou', N'futbol', NULL, CAST(50.00 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[Canchas] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([ProveedorID], [UsuarioID], [Empresa], [Telefono], [Direccion], [FechaRegistro]) VALUES (7, 15, N'Royal', N'987654321', N'Calle Falsa 123', CAST(N'2024-10-15T19:21:41.287' AS DateTime))
INSERT [dbo].[Proveedores] ([ProveedorID], [UsuarioID], [Empresa], [Telefono], [Direccion], [FechaRegistro]) VALUES (9, 15, N'Futbol 2', N'22323', N'gt', CAST(N'2024-10-15T20:07:30.220' AS DateTime))
INSERT [dbo].[Proveedores] ([ProveedorID], [UsuarioID], [Empresa], [Telefono], [Direccion], [FechaRegistro]) VALUES (10, 16, N'Futbol 65', N'2323', N'jr g', CAST(N'2024-10-15T20:14:30.340' AS DateTime))
INSERT [dbo].[Proveedores] ([ProveedorID], [UsuarioID], [Empresa], [Telefono], [Direccion], [FechaRegistro]) VALUES (11, 17, N'Royal', N'12323', N'Jr Guillermo Moore 588', CAST(N'2024-10-15T20:36:27.083' AS DateTime))
INSERT [dbo].[Proveedores] ([ProveedorID], [UsuarioID], [Empresa], [Telefono], [Direccion], [FechaRegistro]) VALUES (12, 18, N'Daniel Furbol', N'987632', N'por ahi', CAST(N'2024-10-15T20:46:56.470' AS DateTime))
INSERT [dbo].[Proveedores] ([ProveedorID], [UsuarioID], [Empresa], [Telefono], [Direccion], [FechaRegistro]) VALUES (13, 16, N'Dezain', N'123456789', N'Calle Falsa', CAST(N'2024-11-19T20:57:04.840' AS DateTime))
INSERT [dbo].[Proveedores] ([ProveedorID], [UsuarioID], [Empresa], [Telefono], [Direccion], [FechaRegistro]) VALUES (14, 18, N'Dezain', N'123456789', N'asda', CAST(N'2024-11-19T21:08:45.560' AS DateTime))
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (15, N'Nicker ', N'pasco', N'npascor@gmail.com', N'2468:<', N'P', CAST(N'2024-10-15T19:18:58.917' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (16, N'Paolo', N'Generro', N'gpos@gmail.com', N'246', N'P', CAST(N'2024-10-15T20:13:53.313' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (17, N'Fabricio', N'Calderon', N'fabricio@gmail.com', N'246', N'P', CAST(N'2024-10-15T20:36:04.550' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (18, N'Daniel', N'Vilca', N'daniel@gmail.com', N'246', N'P', CAST(N'2024-10-15T20:46:33.313' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (19, N'oscar', N'pasco', N'oscar@gmail.com', N'246', N'P', CAST(N'2024-11-18T20:27:51.243' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (20, N'Jorge', N'Castaneda', N'josfaslf@gmail.com', N'kcme', N'P', CAST(N'2024-11-18T20:35:35.907' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (21, N'Prueba', N'Prueba2', N'da@gmail.com', N'246', N'P', CAST(N'2024-11-18T20:41:44.587' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (22, N'Oscar', N'Rodriguez', N'nickeroscar100@gmail.com', N'246', N'P', CAST(N'2024-11-19T18:25:38.647' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (23, N'Fabrizio Alonso', N'Calderon Sanchez', N'u20200085@utp.edu.pe', N'Ge:8=77::B', N'P', CAST(N'2024-11-19T18:55:31.650' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (24, N'Jorge', N'Cardenas', N'jorge.card@gmail.com', N'246', N'P', CAST(N'2024-11-19T20:51:24.803' AS DateTime))
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [Email], [Contraseña], [Perfil], [FechaRegistro]) VALUES (25, N'Oscar', N'Munoz', N'oscar.orr@gmail.com', N'246', N'P', CAST(N'2024-11-19T21:05:42.943' AS DateTime))
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Alquiler__AC48441EFAC49AEC]    Script Date: 19/11/2024 09:22:07 PM ******/
ALTER TABLE [dbo].[Alquileres] ADD UNIQUE NONCLUSTERED 
(
	[CodigoAlquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__A9D10534598CE198]    Script Date: 19/11/2024 09:22:07 PM ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alquileres] ADD  DEFAULT ('Pendiente') FOR [Estado]
GO
ALTER TABLE [dbo].[Canchas] ADD  DEFAULT ((1)) FOR [Disponible]
GO
ALTER TABLE [dbo].[Pagos] ADD  DEFAULT ('Confirmado') FOR [Estado]
GO
ALTER TABLE [dbo].[Pagos] ADD  DEFAULT (getdate()) FOR [FechaPago]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD FOREIGN KEY([CanchaID])
REFERENCES [dbo].[Canchas] ([CanchaID])
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Canchas]  WITH CHECK ADD FOREIGN KEY([ProveedorID])
REFERENCES [dbo].[Proveedores] ([ProveedorID])
GO
ALTER TABLE [dbo].[HorariosCancha]  WITH CHECK ADD FOREIGN KEY([CanchaID])
REFERENCES [dbo].[Canchas] ([CanchaID])
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD FOREIGN KEY([AlquilerID])
REFERENCES [dbo].[Alquileres] ([AlquilerID])
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[ReservaCancha]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Reserva] FOREIGN KEY([AlumnoID])
REFERENCES [dbo].[Alumno] ([AlumnoID])
GO
ALTER TABLE [dbo].[ReservaCancha] CHECK CONSTRAINT [FK_Alumno_Reserva]
GO
ALTER TABLE [dbo].[ReservaCanchas]  WITH CHECK ADD FOREIGN KEY([CanchaID])
REFERENCES [dbo].[Canchas] ([CanchaID])
GO
ALTER TABLE [dbo].[ReservaCanchas]  WITH CHECK ADD FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Alumno] ([AlumnoID])
GO
