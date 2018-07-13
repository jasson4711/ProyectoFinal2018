using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AluminiosEntidades;
using AluminiosNegocio;
using BarcodeLib;

namespace VentaPresentacion
{
    public partial class VentaPresentacion : Form
    {
        bool ventaRealizada = false;
        int idEmpleado = 0;
        int id_venta = 0;
        ClienteEntidad clienteActual = new ClienteEntidad();
        ProductoEntidadMostrar productoActual = new ProductoEntidadMostrar();
        VentaEntidadMostrar currentVentaCabecera = new VentaEntidadMostrar();
        List<DetalleEntidadMostrar> currentVentaDetalle = new List<DetalleEntidadMostrar>();
        List<DetalleEntidadMostrar> listaProductos = new List<DetalleEntidadMostrar>();
        public VentaPresentacion(int Id)
        {
            InitializeComponent();
            LimpiarCampos();
            txtVentaCantidad.ReadOnly = true;
            button1.Enabled = false;
            idEmpleado = Id;

        }

        private void pictureBoxBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarClientes frm = new SeleccionarClientes();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    clienteActual = ClienteNegocio.DevolverClientePorID(frm.IdCliente);
                    LlenarCamposTextoCliente();
                    ventaRealizada = true;
                }
            }
            catch
            {
                MessageBox.Show("No se ha podido obtener el cliente");
            }




        }
        private void EstablecerFilasEditablesDataGridView_DetalleVenta()
        {
            dgvDetallesCompra.Columns[0].ReadOnly = true;
            dgvDetallesCompra.Columns[1].ReadOnly = true;
            dgvDetallesCompra.Columns[2].ReadOnly = true;
            dgvDetallesCompra.Columns[3].ReadOnly = false;
            dgvDetallesCompra.Columns[4].ReadOnly = true;
        }


        private void LlenarCamposTextoCliente()
        {
            txtId.Text = clienteActual.Id.ToString();
            txtNombre.Text = clienteActual.Nombre;
            txtApellido.Text = clienteActual.Apellido;
            txtCedula.Text = clienteActual.Cedula;
            txtDireccion.Text = clienteActual.Direccion;
            txtTelefono.Text = clienteActual.Telefono;
            txtEmail.Text = clienteActual.Email;
            HabilitarBotonesParaEdicionCliente(true);
        }

        private void HabilitarBotonesParaEdicionCliente(bool v)
        {
            btnActualizar.Enabled = v;
            btnLimpiar.Enabled = v;
            btnGuardar.Enabled = !v;
        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            if (!ventaRealizada)
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("¿Seguro que desea cancelar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtCedula.Focus();
            clienteActual = null;
            HabilitarBotonesParaEdicionCliente(false);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    ClienteEntidad clienteModificado = EstablecerCliente();
                    ClienteNegocio.ActualizarCliente(clienteModificado);
                    clienteActual = clienteModificado;
                    LlenarCamposTextoCliente();
                    MessageBox.Show("Actualización correcta");
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al intentar actualizar");
            }


        }

        private ClienteEntidad EstablecerCliente()
        {
            ClienteEntidad cliente = new ClienteEntidad();
            if (txtId.Text.Length > 0)
            {
                cliente.Id = Convert.ToInt32(txtId.Text);
                cliente.Cedula = txtCedula.Text.ToUpper();
                cliente.Nombre = txtNombre.Text.ToUpper();
                cliente.Apellido = txtApellido.Text.ToUpper();
                cliente.Direccion = txtDireccion.Text.ToUpper();
                cliente.Telefono = txtTelefono.Text.ToUpper();
                cliente.Email = txtEmail.Text;
            }
            else
            {
                cliente.Cedula = txtCedula.Text.ToUpper();
                cliente.Nombre = txtNombre.Text.ToUpper();
                cliente.Apellido = txtApellido.Text.ToUpper();
                cliente.Direccion = txtDireccion.Text.ToUpper();
                cliente.Telefono = txtTelefono.Text.ToUpper();
                cliente.Email = txtEmail.Text;
            }


            return cliente;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || txtApellido.Text.Length >= 30)
            {
                //MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || txtNombre.Text.Length >= 30)
            {
                //MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || txtTelefono.Text.Length >= 10)
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    clienteActual = null;
                    clienteActual = EstablecerCliente();
                    ClienteNegocio.GuardarCliente(clienteActual);
                    LlenarCamposTextoCliente();
                    MessageBox.Show("Cliente guardado correctamente");
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al intentar insertar");
            }

        }

        private bool ValidarCampos()
        {
            if (txtCedula.Text == "" || !MetodosAyuda.Metodos.verificadorCédula(txtCedula.Text))
            {
                txtCedula.Focus();
                MessageBox.Show("Ingrese una cédula correcta");
                return false;
            }
            else if (txtApellido.Text == "")
            {
                txtApellido.Focus();
                MessageBox.Show("Ingrese su apellido");
                return false;
            }
            else if (txtNombre.Text == "")
            {
                txtNombre.Focus();
                MessageBox.Show("Ingrese su nombre");
                return false;
            }

            else if (txtDireccion.Text == "")
            {
                txtDireccion.Focus();
                MessageBox.Show("Ingrese su dirección");
                return false;
            }
            else if (txtTelefono.Text == "")
            {
                txtTelefono.Focus();
                MessageBox.Show("Ingrese su teléfono");
                return false;
            }
            //else if (txtEmail.Text == "")
            //{
            //    txtEmail.Focus();
            //    MessageBox.Show("Ingrese su email");
            //    return false;
            //}
            else
            {
                return true;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarProducto frm = new SeleccionarProducto();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    productoActual = ProductoNegocio.DevolverProductoPorID(frm.IdProducto);
                    LlenarCamposTextoProducto();
                    txtVentaCantidad.ReadOnly = false;
                    button1.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("No se ha podido obtener el producto");
            }

        }

        private void LlenarCamposTextoProducto()
        {
            txtVentaNombre.Text = productoActual.Nombre + " " + productoActual.Descripcion;
            txtVentaCantidad.Text = 0 + "";
            txtVentaPrecio.Text = productoActual.Precio.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (VerificarExistenciaMaterial())
            //{
            //    listaProductos.Add(productoActual);
            //    dgvDetallesCompra.DataSource = null;
            //    dgvDetallesCompra.DataSource = listaProductos;
            //}
            AgregarProductosVenta();
        }


        private void txtVentaCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || txtVentaCantidad.Text.Length >= 3)
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void AgregarProductosVenta()
        {
            bool productoYaExiste = false;
            DetalleEntidadMostrar detalle = CrearObjetoDetalle();
            int cant = productoActual.Cantidad;
            if (cant < detalle.Cantidad || cant == 0)
            {
                MessageBox.Show("No dispone de la cantidad especificada.");
            }
            else
            {
                for (int i = 0; i < dgvDetallesCompra.RowCount; i++)
                {

                    if (productoActual.Id == int.Parse(dgvDetallesCompra.Rows[i].Cells["Id"].Value.ToString()))
                    {

                        var cantidadAnterior = Convert.ToInt32(
                            dgvDetallesCompra.Rows[i].Cells["Cantidad"].Value);
                        if (cant < (cantidadAnterior + detalle.Cantidad))
                        {
                            MessageBox.Show("No dispone de la cantidad especificada");
                            productoYaExiste = true;
                            break;
                        }
                        else
                        {
                            dgvDetallesCompra.Rows[i].Cells["Cantidad"].Value =
                            cantidadAnterior + detalle.Cantidad;
                            dgvDetallesCompra.Rows[i].Cells["Precio_Total"].Value =
                                Convert.ToDouble(dgvDetallesCompra.Rows[i].Cells["Precio"].Value) *
                                Convert.ToInt32(dgvDetallesCompra.Rows[i].Cells["Cantidad"].Value);
                            productoYaExiste = true;
                            LimpiarCamposProductos();
                            txtVentaCantidad.ReadOnly = true;
                            button1.Enabled = false;
                            ventaRealizada = true;
                            CalcularMontosVenta();
                        }

                    }

                }
                if (!productoYaExiste)
                {
                    ventaRealizada = true;
                    listaProductos.Add(detalle);
                    dgvDetallesCompra.DataSource = null;
                    dgvDetallesCompra.DataSource = listaProductos;
                    LimpiarCamposProductos();
                    button1.Enabled = false;
                    txtVentaCantidad.ReadOnly = true;
                    productoActual = null;
                    EstablecerFilasEditablesDataGridView_DetalleVenta();
                    CalcularMontosVenta();
                }
            }
        }

        private void CalcularMontosVenta()
        {
            CalcularSubtotal();
            CalcularIva();
            CalcularManoObra();
            CalcularTotal();
        }

        private void CalcularManoObra()
        {
            var manoObra = (Convert.ToDouble(txtSubtotal.Text)) * ConfiguracionApp.Default.PorcentajeGanancia;
            txtManoObra.Text = manoObra.ToString();
        }

        private void CalcularTotal()
        {
            var total = Convert.ToDouble(txtSubtotal.Text) + Convert.ToDouble(txtIva.Text) + Convert.ToDouble(txtManoObra.Text);
            txtTotalPagar.Text = Convert.ToString(total);
        }
        private void CalcularIva()
        {
            var iva = Convert.ToDouble(txtSubtotal.Text) * ConfiguracionApp.Default.Iva;
            txtIva.Text = Convert.ToString(iva);
        }

        private void CalcularSubtotal()
        {
            double subtotal = 0.00;
            for (int i = 0; i < dgvDetallesCompra.RowCount; i++)
            {
                var valorProducto = Convert.ToDouble(dgvDetallesCompra.Rows[i].Cells["Precio_Total"].Value.ToString());
                subtotal += valorProducto;
            }
            txtSubtotal.Text = Convert.ToString(subtotal);
        }

        private DetalleEntidadMostrar CrearObjetoDetalle()
        {
            DetalleEntidadMostrar detalle = new DetalleEntidadMostrar();
            detalle.Id = productoActual.Id;
            detalle.Nombre = productoActual.Nombre;
            detalle.Precio = productoActual.Precio;
            detalle.Cantidad = Convert.ToInt32(txtVentaCantidad.Text);
            return detalle;
        }

        private void LimpiarCamposProductos()
        {
            txtVentaCantidad.Text = "";
            txtVentaNombre.Text = "";
            txtVentaPrecio.Text = "";
        }

        private void dgvDetallesCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                EliminarFilaDataGridView_DetalleVenta();
                CalcularMontosVenta();
            }
        }

        private void EliminarFilaDataGridView_DetalleVenta()
        {
            try
            {
                foreach (var item in listaProductos)
                {
                    if (item.Id == int.Parse(dgvDetallesCompra.CurrentRow.Cells["Id"].Value.ToString()))
                    {
                        listaProductos.Remove(item);
                        dgvDetallesCompra.DataSource = null;
                        dgvDetallesCompra.DataSource = listaProductos;
                    }
                }
            }
            catch (Exception e)
            {

            }


        }
        int cantidad;
        private void dgvDetallesCompra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            foreach (var item in listaProductos)
            {
                if (item.Id == Convert.ToInt32(dgvDetallesCompra.CurrentRow.Cells["Id"].Value.ToString()))
                {
                    if (ProductoNegocio.DevolverProductoPorID(item.Id).Cantidad < Convert.ToInt32(dgvDetallesCompra.CurrentRow.Cells["Cantidad"].Value.ToString()))
                    {
                        MessageBox.Show("No dispone de la cantidad especificada.");
                        dgvDetallesCompra.CurrentRow.Cells["Cantidad"].Value = cantidad;
                    }
                    else
                    {
                        item.Cantidad = Convert.ToInt32(dgvDetallesCompra.CurrentRow.Cells["Cantidad"].Value.ToString());
                        dgvDetallesCompra.DataSource = null;
                        dgvDetallesCompra.DataSource = listaProductos;
                        break;
                    }
                }
            }
            CalcularMontosVenta();

        }

        private void dgvDetallesCompra_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cantidad = Convert.ToInt32(dgvDetallesCompra.CurrentRow.Cells["Cantidad"].Value.ToString());
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea facturar?", "FACTURA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtCedula.Text == "")
                {
                    MessageBox.Show("Por favor cargue un cliente");
                }
                else
                {
                    Facturar();
                    LimpiarCampos();
                    LimpiarCamposProductos();
                    limpiarCamposFactura();
                    dgvDetallesCompra.DataSource = null;
                    listaProductos = new List<DetalleEntidadMostrar>();

                }

            }
        }

        private void ImprimirFactura()
        {
            printDocumentVenta.DocumentName = "Detalle de venta";
            printDialogVenta.Document = printDocumentVenta;
            printDialogVenta.AllowSelection = true;
            printDialogVenta.AllowSomePages = true;
            if (printDialogVenta.ShowDialog() == DialogResult.OK)
            {
                printDocumentVenta.Print();
            }
        }

        private void Facturar()
        {
            try
            {
                VentaEntidad venta = FabricarCabecera();
                id_venta = VentaNegocio.GenerarVenta(venta);
                ProductoNegocio.ActualizarStock(venta.ListaDetalles);
                if (MessageBox.Show("Desea imprimir?", "FACTURA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ImprimirFactura();
                }

            }
            catch
            {
                MessageBox.Show("No se pudo generar la factura");
            }

        }



        private VentaEntidad FabricarCabecera()
        {
            VentaEntidad venta = new VentaEntidad();
            venta.Id_Cliente = Convert.ToInt32(txtId.Text.ToString());
            venta.Id_Empleado = this.idEmpleado;
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
            venta.Fecha = Convert.ToDateTime(fecha);
            venta.Porcentaje_Ganancia = Convert.ToInt32(ConfiguracionApp.Default.PorcentajeGanancia * 100);
            venta.ListaDetalles = FabricarDetalle();

            return venta;

        }

        private List<DetalleEntidad> FabricarDetalle()
        {
            List<DetalleEntidad> detalles = new List<DetalleEntidad>();
            foreach (var item in listaProductos)
            {
                DetalleEntidad detalle = new DetalleEntidad();
                detalle.Id_Pro_Ven = item.Id;
                detalle.Cantidad = item.Cantidad;
                detalle.PrecioUnitario = item.Precio;
                detalles.Add(detalle);
            }

            return detalles;
        }

        private void limpiarCamposFactura()
        {
            txtSubtotal.Text = "";
            txtIva.Text = "";
            txtManoObra.Text = "";
            txtTotalPagar.Text = "";
        }

        private void printDocumentVenta_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 5, y = 5;

            currentVentaCabecera = VentaNegocio.DevolverVentaCabecera(id_venta);
            currentVentaDetalle = VentaNegocio.DevolverVentaDetalle(id_venta);


            Pen blackPen = new Pen(Color.Black, 3);


            Font fuenteCabecera = new Font("Arial", 14, FontStyle.Bold);
            Font fuenteCabecera2 = new Font("Arial", 10, FontStyle.Bold);
            Font fuenteCabecera3 = new Font("Times New Roman", 8, FontStyle.Bold);
            Font fuenteDetalle = new Font("Times New Roman", 8, FontStyle.Regular);

            //MessageBox.Show(e.PageSettings.PaperSize.ToString()); //1100 875
            e.Graphics.DrawString("COMPROBANTE DE VENTA", fuenteCabecera, Brushes.DarkBlue, x + 50, y += 10);
            Image imagen = Properties.Resources.logo1;
            e.Graphics.DrawImage(imagen, x + 325, y, 50, 30);
            e.Graphics.DrawString("ACRIVIDRIO'S", fuenteCabecera2, Brushes.Black, x + 103, y += 20);
            e.Graphics.DrawString("Ruc: 001 340 230 1001", fuenteCabecera2, Brushes.Black, x + 95, y += 20);

            Barcode codigo = new Barcode();
            codigo.IncludeLabel = true;
            Image miCodigo = codigo.Encode(BarcodeLib.TYPE.CODE128, currentVentaCabecera.Cedula + "-" + currentVentaCabecera.Id, Color.Black, Color.White, 400, 100);
            e.Graphics.DrawImage(miCodigo, x, y += 30, miCodigo.Width, miCodigo.Height);
            //Datos cabecera
            e.Graphics.DrawString("Cedula: " + currentVentaCabecera.Cedula, fuenteDetalle, Brushes.Black, x, y += 100);
            e.Graphics.DrawString("Cliente: " + currentVentaCabecera.Apellido + " " + currentVentaCabecera.Nombre, fuenteDetalle, Brushes.Black, x, y += 20);
            e.Graphics.DrawString("Dirección: " + currentVentaCabecera.Direccion, fuenteDetalle, Brushes.Black, x, y += 20);
            e.Graphics.DrawString("Teléfono: " + currentVentaCabecera.Telefono, fuenteDetalle, Brushes.Black, x, y += 20);
            e.Graphics.DrawString("Fecha Vemta: " + currentVentaCabecera.FechaVenta, fuenteDetalle, Brushes.Black, x, y += 20);
            //    //Datos detalle
            e.Graphics.DrawString("Producto", fuenteCabecera3, Brushes.Black, x, y += 40);
            e.Graphics.DrawString("Precio Unitario", fuenteCabecera3, Brushes.Black, x + 100, y);
            e.Graphics.DrawString("Cantidad", fuenteCabecera3, Brushes.Black, x + 200, y);
            e.Graphics.DrawString("Subtotal", fuenteCabecera3, Brushes.Black, x + 300, y);


            foreach (var item in currentVentaDetalle)
            {

                e.Graphics.DrawString(item.Nombre, fuenteDetalle, Brushes.Black, x, y += 20);
                e.Graphics.DrawString(item.Precio.ToString(), fuenteDetalle, Brushes.Black, x + 100, y);
                e.Graphics.DrawString(item.Cantidad.ToString(), fuenteDetalle, Brushes.Black, x + 200, y);
                e.Graphics.DrawString((item.Precio_Total).ToString(), fuenteDetalle, Brushes.Black, x + 300, y);


            }
            e.Graphics.DrawString("Subtotal".ToString(), fuenteDetalle, Brushes.Black, x + 200, y += 20);
            double subtotal = (currentVentaCabecera.Total - currentVentaCabecera.Ganancia) / 1.12;
            e.Graphics.DrawString(subtotal.ToString(), fuenteDetalle, Brushes.Black, x + 300, y);
            e.Graphics.DrawString("Iva".ToString(), fuenteDetalle, Brushes.Black, x + 200, y += 20);
            e.Graphics.DrawString((currentVentaCabecera.Total - currentVentaCabecera.Ganancia - subtotal).ToString(), fuenteDetalle, Brushes.Black, x + 300, y);
            e.Graphics.DrawString("Mano de obra".ToString(), fuenteDetalle, Brushes.Black, x + 200, y += 20);
            e.Graphics.DrawString(currentVentaCabecera.Ganancia.ToString(), fuenteDetalle, Brushes.Black, x + 300, y);

            e.Graphics.DrawString("Total".ToString(), fuenteDetalle, Brushes.Black, x + 200, y += 20);
            e.Graphics.DrawString(currentVentaCabecera.Total.ToString(), fuenteDetalle, Brushes.Black, x + 300, y);
            Rectangle rectangle = new Rectangle(0, 0, 400, y + 40);
            e.Graphics.DrawRectangle(blackPen, rectangle);
        }
    }
}
