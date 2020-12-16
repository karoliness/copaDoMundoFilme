import React from 'react';
import axios from 'axios';
import './App.css';
import SelectButton from './Components/SelectButton/SelectButton'


class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      filmes: [],
      filmesSelecionados: [],
      filmesVencedores: []
    };
  }

  componentDidMount() {
    axios.get(`https://localhost:5001/copafilme`)
      .then(res => {
        const filmes = res.data;
        this.setState({ ...this.state, filmes });
      })
  }

  selecionarFilme(idFilme) {
    if (this.state.filmesSelecionados.length < 8) {
      let filme = this.state.filmes.find(filme => filme.id === idFilme)
      let filmesSelecionados = this.state.filmesSelecionados;
      filmesSelecionados.push(filme);
      this.setState({
        ...this.state, filmesSelecionados
      });
      return true;
    }
    return false;
  }

  deselecionarFilme(idFilme) {
    let filme = this.state.filmes.find(filme => filme.id === idFilme)
    let filmesSelecionados = this.state.filmesSelecionados;
    filmesSelecionados.pop(filme);
    this.setState({
      ...this.state, filmesSelecionados
    });
  }

  gerarCampeonato() {
    axios.post(`https://localhost:5001/copafilme`, this.state.filmesSelecionados)
      .then(res => {
        let filmesVencedores = res.data
        this.setState({ ...this.state, filmesVencedores })
      })
  }

  render() {
    return (
      <div className="App ">
        <div className="AlignCenter">
          <h1 className='AlignText'>CAMPEONATO DE FILMES</h1>
          <h2 className='AlignText'>Fase de Seleção</h2>
          <p className='AlignText'>Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.</p>
        </div>
        <span className='AlignText'>Selecionados: {this.state.filmesSelecionados.length} de 8 filmes</span>
        <button className='Button' type='button' onClick={() => this.gerarCampeonato()}>Gerar meu campeonato</button>
        <div className="Filmes">
          {this.state.filmes.map((filme, key) => {
            return (
              <div key={key}>
                <SelectButton 
                  id={filme.id} 
                  titulo={filme.titulo} 
                  ano={filme.ano}
                  selecionarFilme={() => this.selecionarFilme(filme.id)}
                  deselecionarFilme={() => this.deselecionarFilme(filme.id)} />
              </div>
            )
          })}
        </div>
        <div className="AlignCenter">
          <h1 className='AlignText'>CAMPEONATO DE FILMES</h1>
          <h2 className='AlignText'>Resultado Final</h2>
          <p className='AlignText'>Veja o campeonato de filmes de forma simples e rápida</p>
        </div>
        {this.state.filmesVencedores.map((filme, key) => {
          return (
            <div className="Flex FlexDirectionColumn Content" key={key}>
              <span className="Vencedor">{key+1}º Vencedor </span>
              <span className="Text">{filme.titulo}</span>
              <span className="Text">{filme.ano}</span>
            </div>
          )
        })}
      </div>
    );
  }
}

export default App;
