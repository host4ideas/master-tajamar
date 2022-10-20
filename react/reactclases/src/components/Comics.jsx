import React, { Component } from "react";
import Comic from "./Comic";

export default class Comics extends Component {
    state = {
        comics: [
            {
                titulo: "Spiderman",
                imagen: "https://3.bp.blogspot.com/-i70Zu_LAHwI/T290xxduu-I/AAAAAAAALq8/8bXDrdvW50o/s1600/spiderman1.jpg",
                descripcion: "Hombre araña",
            },
            {
                titulo: "Wolverine",
                imagen: "https://images-na.ssl-images-amazon.com/images/I/51c1Q1IdUBL._SX259_BO1,204,203,200_.jpg",
                descripcion: "Lobezno",
            },
            {
                titulo: "Guardianes de la Galaxia",
                imagen: "https://cdn.normacomics.com/media/catalog/product/cache/1/thumbnail/9df78eab33525d08d6e5fb8d27136e95/g/u/guardianes_galaxia_guadianes_infinito.jpg",
                descripcion: "Yo soy Groot",
            },
            {
                titulo: "Avengers",
                imagen: "https://d26lpennugtm8s.cloudfront.net/stores/057/977/products/ma_avengers_01_01-891178138c020318f315132687055371-640-0.jpg",
                descripcion: "Los Vengadores",
            },
            {
                titulo: "Spawn",
                imagen: "https://i.pinimg.com/originals/e1/d8/ff/e1d8ff4aeab5e567798635008fe98ee1.png",
                descripcion: "Al Simmons",
            },
            {
                titulo: "Batman",
                imagen: "https://www.comicverso.com/wp-content/uploads/2020/06/The-Killing-Joke-657x1024.jpg",
                descripcion: "Murcielago",
            },
        ],
        comicFavorito: null,
    };

    añadirComic = () => {
        const nuevoTitulo = document.getElementById("comicTitulo").value;
        const nuevaImagen = document.getElementById("comicImage").value;
        const nuevaDesc = document.getElementById("comicDesc").value;

        this.state.comics.push({
            titulo: nuevoTitulo,
            imagen: nuevaImagen,
            descripcion: nuevaDesc,
        });

        this.setState({
            comics: this.state.comics,
        });
    };

    borrarComic = (indexOfComic) => {
        this.state.comics.splice(indexOfComic, 1);

        this.setState({
            comics: this.state.comics,
        });
    };

    actualizarComic = (indexOfComic) => {
        const nuevoTitulo = document.getElementById("comicTitulo").value;
        const nuevaImagen = document.getElementById("comicImage").value;
        const nuevaDesc = document.getElementById("comicDesc").value;

        this.setState({
            comics: this.state.comics.filter((comic, index) => {
                if (index === indexOfComic) {
                    comic.titulo = nuevoTitulo;
                    comic.imagen = nuevaImagen;
                    comic.descripcion = nuevaDesc;
                }
                return true;
            }),
        });
    };

    favorito = (indexOfComic) => {
        console.log(this.state.comics[indexOfComic]);

        this.setState({
            comicFavorito: this.state.comics[indexOfComic],
        });
    };

    render() {
        return (
            <div>
                <h1>Comics</h1>
                <div>
                    <h2>Comic favorito</h2>
                    {this.state.comicFavorito && (
                        <div
                            style={
                                ({ border: "1px solid black" },
                                { borderRadius: "5px" })
                            }
                        >
                            <h3>Titulo: {this.state.comicFavorito.titulo}</h3>
                            <h3>
                                Titulo: {this.state.comicFavorito.descripcion}
                            </h3>
                            <img
                                style={{ width: "150px" }}
                                src={this.state.comicFavorito.imagen}
                                alt="Comic"
                            ></img>
                        </div>
                    )}
                </div>
                <fieldset>
                    <legend>Añadir un comic</legend>

                    <div
                        style={
                            ({ display: "flex" }, { flexDirection: "column" })
                        }
                    >
                        <label htmlFor="comicTitulo">Titulo</label>
                        <input type="text" id="comicTitulo" />

                        <br />

                        <label htmlFor="comicDesc">Descripcion</label>
                        <input type="text" id="comicDesc" />

                        <br />

                        <label htmlFor="comicImage">Imagen</label>
                        <input type="file" id="comicImage" />
                    </div>

                    <button onClick={this.añadirComic}>Añadir comic</button>
                </fieldset>
                <br />
                <fieldset>
                    <legend>Update a comic</legend>
                </fieldset>
                <br />
                <hr />
                {this.state.comics.map((comic, index) => {
                    return (
                        <Comic
                            key={index}
                            index={index}
                            comic={comic}
                            borrarComic={this.borrarComic}
                            favorito={this.favorito}
                            actualizarComic={this.actualizarComic}
                        />
                    );
                })}
            </div>
        );
    }
}
