import './Loading.css'
import React from "react";

export const BoxLoading: React.FC = () => (
    <div>
        <div className="box">
            <div className="has-text-centered">
                <div className="lds-roller"><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>
                <h3 className="is-size-5">Loading...</h3>
            </div>
        </div>
    </div>
)