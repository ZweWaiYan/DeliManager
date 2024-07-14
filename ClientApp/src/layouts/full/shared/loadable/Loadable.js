import React, { Suspense } from "react";

const Loadable = (Component) => (props) =>
(
  <Suspense fallback={<Loading />}>
    <Component {...props} />
  </Suspense>
);

function Loading() {
  return <h2>🌀 Loading...</h2>;
}

export default Loadable;
