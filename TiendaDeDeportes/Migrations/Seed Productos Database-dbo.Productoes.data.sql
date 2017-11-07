SET IDENTITY_INSERT [dbo].[Productoes] ON
INSERT INTO [dbo].[Productoes] ([ProductoId], [Nombre], [Descripcion], [Precio], [Categoria]) VALUES (1, N'Kayak', N'Bote para una Persona', CAST(2000.00 AS Decimal(18, 2)), N'Deportes De Agua')
INSERT INTO [dbo].[Productoes] ([ProductoId], [Nombre], [Descripcion], [Precio], [Categoria]) VALUES (2, N'Chaleco Salvavidas', N'Color Rojo', CAST(900.00 AS Decimal(18, 2)), N'Deportes De Agua')
INSERT INTO [dbo].[Productoes] ([ProductoId], [Nombre], [Descripcion], [Precio], [Categoria]) VALUES (3, N'Pelota de Futbol', N'De acuerdo a estandares de FIFA', CAST(1000.00 AS Decimal(18, 2)), N'Futbol')
INSERT INTO [dbo].[Productoes] ([ProductoId], [Nombre], [Descripcion], [Precio], [Categoria]) VALUES (4, N'Banderines de Corner', N'x4 Color Rojo', CAST(500.00 AS Decimal(18, 2)), N'Futbol')
INSERT INTO [dbo].[Productoes] ([ProductoId], [Nombre], [Descripcion], [Precio], [Categoria]) VALUES (5, N'Estadio', N'Capacidad de 35000 Asientos', CAST(9000000.00 AS Decimal(18, 2)), N'Futbol')
INSERT INTO [dbo].[Productoes] ([ProductoId], [Nombre], [Descripcion], [Precio], [Categoria]) VALUES (7, N'Mesa de Ajedrez', N'80x80 cm ', CAST(1200.00 AS Decimal(18, 2)), N'Ajedrez')
INSERT INTO [dbo].[Productoes] ([ProductoId], [Nombre], [Descripcion], [Precio], [Categoria]) VALUES (8, N'Piezas de Ajedrez', N'Hechas de Madera', CAST(500.00 AS Decimal(18, 2)), N'Ajedrez')
SET IDENTITY_INSERT [dbo].[Productoes] OFF
