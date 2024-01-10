import React, { useEffect } from "react";
import ReactDom from "react-dom";
import profileStyles from "./Profile.module.css";
import { _get } from "../utils/api";
import { useState } from "react";
import jwt from "jwt-decode";
import { getToken } from "../utils/storage";

export default function Post(props) {
    const {imagePath, description} = props;
  
    return (
    <div className={profileStyles.postDiv}>
      <img
        className={profileStyles.postImage}
        src={imagePath}
        alt=""
        srcSet=""
      />
      <p className={profileStyles.postDesc}>{description}</p>
    </div>
  );
}
