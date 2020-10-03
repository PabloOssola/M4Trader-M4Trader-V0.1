const structure = [
    { id: 0, label: "Home", link: "/app/dashboard", icon: <HomeIcon /> },
    {
      id: 1,
      label: "Consultas",
      link: "/app/consultas",
      icon: <SvgIconSearch />,
      children: [
        { label: "Administración de saldos", link: "/app/consultas/administracionDeSaldos" },
        { label: "Operaciones historicas de cliente", link: "/app/consultas/operacionesHistoricoCliente" },
        { label: "Cotizaciones historicas", link: "/app/consultas/cotizacionesHistoricas" },
        { label: "Datos del cliente", link: "/app/consultas/datosDelCliente" },
      ]
    },
  
    {
      id: 2,
      label: "Estadística",
      link: "/app/estadistica",
      icon: <SvgIconStatatics />,
      children: [
        { label: "Datos historicos", link: "/app/estadistica/datosHistorico" },
  
      ]
    },
  
    {
      id: 3,
      label: "Administración de usuarios",
      link: "/app/usuarios",
      icon: <SvgIconAdminUser />,
      children: [
        { label: "Gestion", link: "/app/usuarios/consultar" },
  
      ]
    },
    {
      id: 4,
      label: "Mensajes y alertas",
      link: "/app/mensajes",
      icon: <SvgIconMessageAlert />,
      children: [
        { label: "Crear", link: "/app/mensajes/crear" },
        { label: "Enviados", link: "/app/mensajes/enviados" },
        { label: "Recibidos", link: "/app/mensajes/recibidos" },
  
      ]
    },
    {
      id: 5,
      label: "Precios y Pizarra",
      link: "/app/preciosYPizarra",
      icon: <SvgIconPrecioPizarra />,
      children: [
        { label: "Precios", link: "/app/preciosYPizarra/precios" },
        { label: "Pizarra", link: "/app/preciosYPizarra/pizarra" },
      ]
    }
  
  ];
  
  export default structure;