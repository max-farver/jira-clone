import React from "react";

const Layout = ({ children }) => {
  return (
    <div className="h-screen">
      <Nav />
      <main className="lg:grid grid-cols-5 h-full">{children}</main>
    </div>
  );
};

export default Layout;
