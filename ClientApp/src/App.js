import { CssBaseline, ThemeProvider , Box , CircularProgress } from '@mui/material';
import { useRoutes } from 'react-router-dom';
import Router from './routes/Router';

import { baselightTheme } from "./theme/DefaultColors";
import { connect } from 'react-redux';

import * as actions from './../src/actions/authActions';
import { useEffect , useState } from 'react';

function App({ auth, fetchUser }) {    
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      await fetchUser();
      setLoading(false);
    };

    fetchData();
  }, [fetchUser]);

  const routing = useRoutes(Router(auth.isAuth));
  const theme = baselightTheme;  

  return (
    loading ?
      <Box
        sx={{
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          height: '100vh',
        }}
      >
        <CircularProgress />
      </Box>
      :
      <ThemeProvider theme={theme}>
        <CssBaseline />
        {routing}
      </ThemeProvider>
  );
};

// export default App;

function mapStateToProps(state) {
  return { auth: state.auth };
}

export default connect(mapStateToProps, actions)(App);

