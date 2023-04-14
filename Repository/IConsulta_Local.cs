using ProjetoFamiliaAdvogado.Model.Cadastro;
using ProjetoFamiliaAdvogado.Model.Erro;
using ProjetoFamiliaAdvogado.Model.Justica;
using ProjetoFamiliaAdvogado.Model.Login;

namespace ProjetoFamiliaAdvogado.Repository
{
    public interface IConsulta_Local
    {
        #region Login

        Task<List<LoginModel>> GetAllLogin();

        Task<LoginModel> GetLoginByID(int loginModel);

        Task<int> AddLogin(LoginModel loginModel);

        Task<int> UpdateLogin(LoginModel loginModel);

        Task<int> DeleteLogin(LoginModel loginModel);

        Task<LoginModel> ObtemLogin(string nome, string senha);

        #endregion


        #region LoginSessao

        Task<List<LoginSessaoModel>> GetAllLoginGeral();

        Task<LoginSessaoModel> GetLoginGeralByID(int loginGeralModel);

        Task<int> AddLoginGeral(LoginSessaoModel loginGeralModel);

        Task<int> UpdateLoginGeral(LoginSessaoModel loginGeralModel);

        Task<int> DeleteLoginGeral(LoginSessaoModel loginGeralModel);

        #endregion


        #region Usuario

        Task<List<UsuarioModel>> GetAllUsuario();

        Task<UsuarioModel> GetUsuarioByID(int usuarioModel);

        Task<UsuarioModel> GetUsuarioImageByID(int usuarioModel);

        Task<int> AddUsuario(UsuarioModel usuarioModel);

        Task<int> UpdateUsuario(UsuarioModel usuarioModel);

        Task<int> DeleteUsuario(UsuarioModel usuarioModel);

        #endregion


        #region Erro

        Task<List<ErroModel>> GetAllErroModel();

        Task<ErroModel> GetErroModelByID(int erroModel);

        Task<int> AddErroModel(ErroModel erroModel);

        Task<int> UpdateErroModel(ErroModel erroModel);

        Task<int> DeleteErroModel(ErroModel erroModel);

        #endregion


        #region Audiencia

        Task<List<AudienciaModel>> GetAllAudienciaModel();

        Task<AudienciaModel> GetAudienciaModelByID(int audienciaModel);

        Task<int> AddAudienciaModel(AudienciaModel audienciaModel);

        Task<int> UpdateAudienciaModel(AudienciaModel audienciaModel);

        Task<int> DeleteAudienciaModel(AudienciaModel audienciaModel);

        #endregion


        #region Anotacao

        Task<List<AnotacoesModel>> GetAllAnotacoesModel();

        Task<AnotacoesModel> GetAnotacoesModelByID(int anotacoesModel);

        Task<int> AddAnotacoesModel(AnotacoesModel anotacoesModel);

        Task<int> UpdateAnotacoesModel(AnotacoesModel anotacoesModel);

        Task<int> DeleteAnotacoesModel(AnotacoesModel anotacoesModel);

        #endregion


        #region Cliente

        Task<List<ClienteModel>> GetAllClienteModel();

        Task<ClienteModel> GetClienteModelByID(int clienteModel);

        Task<int> AddClienteModel(ClienteModel clienteModel);

        Task<int> UpdateClienteModel(ClienteModel clienteModel);

        Task<int> DeleteClienteModel(ClienteModel clienteModel);

        #endregion
    }
}
