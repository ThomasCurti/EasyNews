import React from "react";

// CSS
import '../Assets/scss/Home.scss';

import HomeBlockLeft from "../Components/HomeBlockLeft";
import HomeBlockRight from "../Components/HomeBlockRight";

let sampleText = "Conpingerentur sunt ex suam Asbolius ex ex negotio latius unde vitamque ea petitam ex latius inpetrarunt Sericus suam negotio palaestrita Asbolius autem conpingerentur conpingerentur se adseverantes hi hi autem vitamque negotio praefectum Olybrium Asbolius praefectum unde vincula latius se funditabat tali negotio sunt vitamque suam suam eius et Maxima Campensis petitam.";

const GamePage = () => {
    return (
        <div className="Home">
            <div className="Home_Title">Apprenez en jouant !</div>
            <div className={"gameDl"}>Télécharger Easy News le jeu</div>

            <HomeBlockLeft
                title={"Niveau 1"}
                imageText={"On peut faire ça"}
                text={sampleText}
            />

            <HomeBlockRight
                title={"Niveau 2"}
                imageText={"Mais aussi ça"}
                text={sampleText}
            />

            <HomeBlockLeft
                title={"Comment installer"}
                imageText={"Comment on installe"}
                text={sampleText}
            />

            <HomeBlockRight
                title={"Comment jouer"}
                imageText={"Comment on joue"}
                text={sampleText}
            />

        </div>
    );
};

export default GamePage;