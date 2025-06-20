# WindowsServiceToolsApp

Ferramenta WinForms para **instalar** e **remover serviços Windows** via interface gráfica.

---

## ✅ Funcionalidades

- Instalação de serviço Windows (`sc create`)
- Remoção de serviço (`sc stop` + `sc delete`)
- Auto preenchimento do nome do serviço lendo o AppSettings (`NOME_SERVICO`) do `.exe.config`
- Log com saída padrão do `sc.exe`, erros, exit codes e mensagens de exceção
- Validação de nome de serviço (máx. 256 caracteres, sem vazio)
- Check de permissões: obriga rodar como **Administrator**

---

## 💻 Requisitos de Ambiente

| Item                     | Detalhe                     |
|------------------------- |-----------------------------|
| .NET Runtime             | .NET 6 ou .NET 8 (SDK ou runtime) |
| Sistema Operacional      | Windows (qualquer versão com suporte a serviços Windows) |
| Permissão                | Executar o app como **Administrador** |
| Serviço alvo             | Precisa ser um executável `.exe` que implemente um serviço Windows |

---

## 🚀 Como Executar

1. **Build do projeto**
Abra com Visual Studio 2022/2024 (SDK-style project targeting `.NET 6` ou `.NET 8`)

2. **Rodar como Administrador**
Necessário para criar ou excluir serviços.

3. **Usar a Interface**

| Ação                      | Passos |
|---------------------------|------|
| Instalar Serviço          | Browse > Escolher .exe > Confirmar Nome > Install |
| Desinstalar Serviço       | Informar Nome > Uninstall |
| Limpar Log                | Botão "Clear Log" |

---

## 🛠️ Sobre o carregamento automático do nome do serviço

Se o executável tiver um arquivo de configuração (exemplo: `MeuServico.exe.config`), o app tentará ler a seguinte chave:

```xml
<appSettings>
  <add key="NOME_SERVICO" value="MeuServicoWindows" />
</appSettings>
```

Se encontrado, o campo **Service Name** será preenchido automaticamente.

---

## ⚠️ Limitações e Observações

- Apenas **instalação** e **remoção** de serviços.
- Não realiza Start/Stop automático após instalar.
- Não verifica se o executável é realmente um `Windows Service` válido.
- Internamente usa o `sc.exe`.
- Logs são apenas informativos (não persistem após fechar o app).

---

## 📂 Estrutura do Projeto

```
WindowsServiceToolsApp/
├── Form1.cs
├── Form1.Designer.cs
├── Program.cs
├── WindowsServiceToolsApp.csproj
└── README.md
```

---

## 🧱 Build via CLI (opcional)

```bash
dotnet build -c Release
```

Gera o executável na pasta:

```
.bin\Release
et6.0-windows```
ou
```
.bin\Release
et8.0-windows```

---

## ✅ Próximas Melhorias Sugeridas

- Validar se o EXE realmente implementa um Service (ex.: via reflection ou `sc qc`)
- Adicionar Start/Stop/Restart
- Permitir escolher tipo de start (`auto`, `manual`, etc)
- Exportar log para arquivo .txt

---
