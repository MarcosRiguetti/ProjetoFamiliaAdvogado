using Microsoft.AspNetCore.Components;
using ProjetoFamiliaAdvogado.Model.Cadastro;
using ProjetoFamiliaAdvogado.Model.Erro;
using ProjetoFamiliaAdvogado.Model.Justica;
using ProjetoFamiliaAdvogado.Model.Login;
using SQLite;

namespace ProjetoFamiliaAdvogado.Repository
{
    public class Consulta_Local : IConsulta_Local
    {
        private SQLiteAsyncConnection _dbConnection;

        [Parameter]
        public int IdErro { get; set; }

        public Consulta_Local()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            try
            {
                if (_dbConnection == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Consulta.db3");
                    _dbConnection = new SQLiteAsyncConnection(dbPath);
                    await _dbConnection.CreateTablesAsync<LoginModel, UsuarioModel, LoginSessaoModel, AudienciaModel, AnotacoesModel>();
                    await _dbConnection.CreateTablesAsync<ErroModel, ClienteModel>();
                }
            }
            catch (Exception ex)
            {
                RegistrarErro(ex);
                throw;
            }
        }

        public async void RegistrarErro(Exception ex)
        {
            try
            {
                if (ex.InnerException != null)
                {
                    var erroModel = new Model.Erro.ErroModel
                    {
                        IdErro = IdErro,
                        Classe = ex.TargetSite.DeclaringType.Name,
                        Metodo = ex.TargetSite.Name,
                        Mensagem = ex.Message,
                        MensagemInterna = ex.InnerException.Message,
                        DataErro = DateTime.Now
                    };

                    int response = -1;
                    if (IdErro == 0)
                    {
                        response = await AddErroModel(erroModel);
                    }
                }
                else
                {
                    var erroModel = new Model.Erro.ErroModel
                    {
                        IdErro = IdErro,
                        Classe = ex.TargetSite.DeclaringType.Name,
                        Metodo = ex.TargetSite.Name,
                        Mensagem = ex.Message,
                        MensagemInterna = "",
                        DataErro = DateTime.Now
                    };

                    int response = -1;
                    if (IdErro == 0)
                    {
                        response = await AddErroModel(erroModel);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Login

        Task<LoginModel> IConsulta_Local.ObtemLogin(string nome, string senha)
        {
            var usuario = _dbConnection
                .Table<LoginModel>()
                .Where(x => x.Usuario == nome && x.Password == senha)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<int> AddLogin(LoginModel loginModel)
        {
            return await _dbConnection.InsertAsync(loginModel);
        }

        public async Task<int> DeleteLogin(LoginModel loginModel)
        {
            return await _dbConnection.DeleteAsync(loginModel);
        }

        public async Task<List<LoginModel>> GetAllLogin()
        {
            return await _dbConnection.Table<LoginModel>().ToListAsync();
        }

        public async Task<int> UpdateLogin(LoginModel loginModel)
        {
            return await _dbConnection.UpdateAsync(loginModel);

        }

        public async Task<LoginModel> GetLoginByID(int LoginID)
        {
            var login = await _dbConnection.QueryAsync<LoginModel>($"Select * From {nameof(LoginModel)} where LoginID={LoginID}");
            return login.FirstOrDefault();
        }

        #endregion


        #region Usuario

        public async Task<int> AddUsuario(UsuarioModel usuarioModel)
        {
            return await _dbConnection.InsertAsync(usuarioModel);
        }

        public async Task<int> DeleteUsuario(UsuarioModel usuarioModel)
        {
            return await _dbConnection.DeleteAsync(usuarioModel);
        }

        public async Task<List<UsuarioModel>> GetAllUsuario()
        {
            return await _dbConnection.Table<UsuarioModel>().ToListAsync();
        }

        public async Task<int> UpdateUsuario(UsuarioModel usuarioModel)
        {
            return await _dbConnection.UpdateAsync(usuarioModel);
        }

        public async Task<UsuarioModel> GetUsuarioByID(int IdUsuario)
        {
            var usuario = await _dbConnection.QueryAsync<UsuarioModel>($"Select * From {nameof(UsuarioModel)} where IdUsuario={IdUsuario}");
            return usuario.FirstOrDefault();
        }

        public async Task<UsuarioModel> GetUsuarioImageByID(int IdUsuario)
        {
            var usuario = await _dbConnection.QueryAsync<UsuarioModel>($"Select UserAvatar From {nameof(UsuarioModel)} where IdUsuario={IdUsuario}");
            return usuario.FirstOrDefault();
        }

        #endregion


        #region LoginSessao

        public Task<int> AddLoginGeral(LoginSessaoModel loginGeralModel)
        {
            return _dbConnection.InsertAsync(loginGeralModel);
        }

        public Task<int> DeleteLoginGeral(LoginSessaoModel loginGeralModel)
        {
            return _dbConnection.DeleteAsync(loginGeralModel);
        }

        public Task<List<LoginSessaoModel>> GetAllLoginGeral()
        {
            return _dbConnection.Table<LoginSessaoModel>().ToListAsync();
        }

        public Task<int> UpdateLoginGeral(LoginSessaoModel loginGeralModel)
        {
            return _dbConnection.UpdateAsync(loginGeralModel);
        }

        public async Task<LoginSessaoModel> GetLoginGeralByID(int LoginGeralID)
        {
            var login = await _dbConnection.QueryAsync<LoginSessaoModel>($"Select * From {nameof(LoginSessaoModel)} where LoginGeralID={LoginGeralID}");
            return login.FirstOrDefault();
        }

        #endregion


        #region Erro

        public async Task<List<ErroModel>> GetAllErroModel()
        {
            return await _dbConnection.Table<ErroModel>().ToListAsync();
        }

        public async Task<ErroModel> GetErroModelByID(int ErroID)
        {
            var erro = await _dbConnection.QueryAsync<ErroModel>($"Select * From {nameof(ErroModel)} where ErroID={ErroID}");
            return erro.FirstOrDefault();
        }

        public async Task<int> AddErroModel(ErroModel erroModel)
        {
            return await _dbConnection.InsertAsync(erroModel);
        }

        public async Task<int> UpdateErroModel(ErroModel erroModel)
        {
            return await _dbConnection.UpdateAsync(erroModel);
        }

        public async Task<int> DeleteErroModel(ErroModel erroModel)
        {
            return await _dbConnection.DeleteAsync(erroModel);
        }

        #endregion


        #region Audiencia

        public Task<int> AddAudienciaModel(AudienciaModel audienciaModel)
        {
            return _dbConnection.InsertAsync(audienciaModel);
        }

        public Task<int> DeleteAudienciaModel(AudienciaModel audienciaModel)
        {
            return _dbConnection.DeleteAsync(audienciaModel);
        }

        public Task<List<AudienciaModel>> GetAllAudienciaModel()
        {
            return _dbConnection.Table<AudienciaModel>().ToListAsync();
        }

        public Task<int> UpdateAudienciaModel(AudienciaModel audienciaModel)
        {
            return _dbConnection.UpdateAsync(audienciaModel);
        }

        public async Task<AudienciaModel> GetAudienciaModelByID(int IdAudiencia)
        {
            var audiencia = await _dbConnection.QueryAsync<AudienciaModel>($"Select * From {nameof(AudienciaModel)} where IdAudiencia={IdAudiencia}");
            return audiencia.FirstOrDefault();
        }

        #endregion


        #region Anotacoes

        public Task<int> AddAnotacoesModel(AnotacoesModel anotacoesModel)
        {
            return _dbConnection.InsertAsync(anotacoesModel);
        }

        public Task<int> DeleteAnotacoesModel(AnotacoesModel anotacoesModel)
        {
            return _dbConnection.DeleteAsync(anotacoesModel);
        }

        public Task<List<AnotacoesModel>> GetAllAnotacoesModel()
        {
            return _dbConnection.Table<AnotacoesModel>().ToListAsync();
        }

        public Task<int> UpdateAnotacoesModel(AnotacoesModel anotacoesModel)
        {
            return _dbConnection.UpdateAsync(anotacoesModel);
        }

        public async Task<AnotacoesModel> GetAnotacoesModelByID(int IdAnotacoes)
        {
            var anotacoes = await _dbConnection.QueryAsync<AnotacoesModel>($"Select * From {nameof(AnotacoesModel)} where IdAnotacoes={IdAnotacoes}");
            return anotacoes.FirstOrDefault();
        }

        #endregion


        #region Cliente

        public Task<int> AddClienteModel(ClienteModel clienteModel)
        {
            return _dbConnection.InsertAsync(clienteModel);
        }

        public Task<int> DeleteClienteModel(ClienteModel clienteModel)
        {
            return _dbConnection.DeleteAsync(clienteModel);
        }

        public Task<List<ClienteModel>> GetAllClienteModel()
        {
            return _dbConnection.Table<ClienteModel>().ToListAsync();
        }

        public Task<int> UpdateClienteModel(ClienteModel clienteModel)
        {
            return _dbConnection.UpdateAsync(clienteModel);
        }

        public async Task<ClienteModel> GetClienteModelByID(int ClienteModelID)
        {
            var cliente = await _dbConnection.QueryAsync<ClienteModel>($"Select * From {nameof(ClienteModel)} where ClienteModelID={ClienteModelID}");
            return cliente.FirstOrDefault();
        }

        #endregion
    }
}
