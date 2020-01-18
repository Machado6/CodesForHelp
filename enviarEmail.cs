//Incluir esses namespaces
using System.Net;
using System.Net.Mail;
 
//Método para envio de e-mail
public string EnviarEmail(string emailFrom, string nomeFrom, List<string> emailPara, string assunto, string texto)
{
    //Gerando o objeto da mensagem
    MailMessage msg = new MailMessage();
    //Remetente
    msg.From = new MailAddress(emailFrom, nomeFrom);
    //Destinatários
    foreach(string email in emailPara)
        msg.To.Add(email);
    //Assunto
    msg.Subject = assunto;
    //Texto a ser enviado
    msg.Body = texto;
    msg.IsBodyHtml = true;
 
    //Gerando o objeto para envio da mensagem (Exemplo pelo Gmail)
    SmtpClient client = new SmtpClient();
    client.UseDefaultCredentials = true;
    client.Host = "smtp.gmail.com";
    client.Port = 587;
    client.EnableSsl = true;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.Credentials = new NetworkCredential("SeuEmail@gmail.com", "SuaSenha");
    try
    {
    client.Send(msg);
    return "Mensagem enviada com sucesso!";
    }
    catch (Exception ex)
    {
    return "Falha: " + ex.Message;
    }
    finally
    {
    msg.Dispose();
    }
}