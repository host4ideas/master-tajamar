using System.Data.SqlClient;

#region PROCEDIMIENTOS ALMACENADOS

/*
	Procedure del ejercicio para actualizar el salario de un hospital si supera el millon
*/
/*
CREATE PROCEDURE SP_HOSPITALES
AS
	SELECT * FROM HOSPITAL;
GO

CREATE PROCEDURE SP_UPDATESALARIOSHOSPITAL
(@NOMBRE NVARCHAR(50))
AS
    DECLARE @SUELDO_TOTAL INT
	DECLARE @HOSPITALCOD INT

	SELECT @HOSPITALCOD = HOSPITAL_COD FROM HOSPITAL WHERE NOMBRE = 'La Paz';
SELECT* FROM PLANTILLA WHERE HOSPITAL_COD = @HOSPITALCOD;

SELECT @SUELDO_TOTAL = SUM(CAST(SALARIO AS int)) FROM PLANTILLA
	WHERE NOMRE = @NOMBRE;

IF(@SUELDO_TOTAL > 1000000) BEGIN
    UPDATE PLANTILLA SET SALARIO = SALARIO - 10000 WHERE HOSPITAL_COD = @HOSPITALCOD;
PRINT 'DISMINUCION SALARIO EN 10000'

    END
    ELSE BEGIN
		UPDATE PLANTILLA SET SALARIO = SALARIO + 10000 WHERE HOSPITAL_COD = @HOSPITALCOD;
PRINT 'AUMENTO SALARIO EN 10000'

    END
GO

EXEC SP_HOSPITALES;
*/
#endregion

namespace AdoNet
{
    public partial class Form07ProcedimientoUpdatePlantilla : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader? reader;

        public Form07ProcedimientoUpdatePlantilla()
        {
            InitializeComponent();
            this.cn = new("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.cmd = this.cn.CreateCommand();
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_HOSPITALES";
            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.cmbHospitales.Items.Clear();
            while (this.reader.Read())
            {
                string nombre = (string)this.reader["NOMBRE"];
                this.cmbHospitales.Items.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = (string)this.cmbHospitales.SelectedItem;
            SqlParameter paramNombre = new SqlParameter("@NOMBRE", nombre);
            this.cmd.Parameters.Add(paramNombre);
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_UPDATESALARIOSHOSPITAL";
            this.cn.Open();
            this.lstPlantilla.Items.Clear();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                string apellido = (string)this.reader["APELLIDO"];
                string funcion = (string)this.reader["FUNCION"];
                string salario = (string)this.reader["SALARIO"];
                this.lstPlantilla.Items.Add(apellido + ", " + funcion + ", " + salario);
            }
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();
        }
    }
}
