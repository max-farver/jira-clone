import React from "react";
import NextDocument, { Head, Main, NextScript } from "next/document";

export default class Document extends NextDocument {
  render() {
    return (
      <html lang="en">
        <Head>
          <link rel="stylesheet" href="https://rsms.me/inter/inter.css" />
        </Head>
        <body>
          <Main />
          <NextScript />
        </body>
      </html>
    );
  }
}
