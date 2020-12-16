import React, { Component } from 'react';
import './SelectButton.css';

class SelectButton extends Component {
  constructor(props) {
    super(props);
    this.state = {
      active: false
    };
  }

  selecionar() {
    if (this.state.active) {
      this.props.deselecionarFilme(this.props.id);
      this.setState({ active: false });
      return;
    }
    let selecionou = this.props.selecionarFilme(this.props.id)
    if (selecionou) {
      this.setState({ active: true });
    }
  }

  render() {
    return (
      <button onClick={() => this.selecionar()} className={`Box ${this.state.active ? 'BoxSelected' : ''}`}>
        <div className="Detail">
          <span className="Title">{this.props.titulo}</span>
          <span>{this.props.ano}</span>
        </div>
      </button>
    );
  }
}

export default SelectButton