﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmartFeedback.Data.Dtos;
using SmartFeedback.Models;

namespace SmartFeedback.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signInManager;
    private TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService? tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task CadastrarUsuario(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Erro ao cadastrar usuário: " + string.Join(", ", resultado.Errors.Select(e => e.Description)));
        }
    }

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Erro ao fazer login: usuário ou senha inválidos.");
        }

        var usuario = _signInManager.UserManager.Users
            .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());
        
        var token = _tokenService.GerarToken(usuario);

        return token;
    }
}