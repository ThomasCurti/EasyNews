import React from "react";

// CSS
import '../Assets/scss/Home.scss';
import '../Assets/scss/GamePage.scss';

// img
import background from '../../public/BackgroundAccueil.png';

// Game
import game from '../../public/V1.zip';

import HomeBlockLeft from "../Components/HomeBlockLeft";
import HomeBlockRight from "../Components/HomeBlockRight";
import DownloadButton from "../Components/DownloadButton";

const GamePage = () => {
    return (
        <div className="Home">
            <div className="Home_Title">Apprenez en jouant !</div>

            <div>
                <img src={background} className="gameImage" alt={"BackgroundAccueil"}/>

                <div className="gameImageContainer">
                    <DownloadButton filepath={game}>
                        <h2>Télécharger le jeu en cliquant ici</h2>
                    </DownloadButton>
                    <p>Jouable par les petits mais aussi par les grands !</p>
                </div>
            </div>

            <HomeBlockLeft
                title={"Comment installer"}
                imageText={"Comment on installe"}
                text={"Cliquer sur le lien ci-dessus pour télécharger le jeu.\n Une fois que vous aurez téléchargé le jeu, dézippez le dossier V1.zip (clique droit -> extraire tout). Une fois le dossier décompressé, ils vous suffit d'executer le fichier EasyNews_TheGame.exe en double cliquant dessus"}
            />

            <HomeBlockRight
                title={"Comment jouer"}
                imageText={"Comment on joue"}
                text={"Lorsque vous arriverez sur le menu du jeu, sélectionnez un niveau. Les niveaux sont décrit ci-dessous. Lorsque vous démarrerez un niveau, un mini tutoriel vous expliquera comment jouer au jeu. Vous pourrez, par la suite, jouer au jeu et apprendre de nouvelles choses facilement"}
            />

            <HomeBlockLeft
                title={"Niveau 1"}
                imageText={"Les virus"}
                text={"Le niveau 1 est basé sur la gestion de crise lors de l'apparation de virus. Vous pourrez apprendre et comprendre les gestes ou actions que vous pourrez faire pour sauver le monde. Vous devrez par ailleurs aussi essayer de sauvver le monde en ordonnant à la population d'effectuer certaines actions pour contrer le virus. Attention à bien agir, sinon les populations ne voudront plus vous suivre..."}
            />

            <HomeBlockRight
                title={"Niveau 2"}
                imageText={"Réchauffement climatique"}
                text={"Le niveau 2 est basé sur la gestion de la crise climatique actuelle. Vous pourrez apprendre et comprendres les gestes ou actions que vous pourrez faire pour aider à sauver le monde. Dans ce niveau, vous devrez aider l'islande à mieux gérer la pollution de son pays en utilisant des énergies propres et durables. Attention tout de même à l'économie de votre pays, vous ne voulez pas non plus faire faillite..."}
            />

        </div>
    );
};

export default GamePage;
