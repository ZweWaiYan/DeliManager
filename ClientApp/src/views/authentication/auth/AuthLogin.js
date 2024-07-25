import React, { useState, useCallback } from 'react';
import {
    Box,
    Typography,
    FormGroup,
    FormControlLabel,
    Button,
    Stack,
    Checkbox,
    TextField,
} from '@mui/material';
import { Link, useNavigate } from 'react-router-dom';
import CustomTextField from '../../../components/forms/theme-elements/CustomTextField';
import { connect } from 'react-redux';
import * as actions from '../../../actions/authActions';
import { signIn } from '../../../api/AuthAPI';

const AuthLogin = ({ title, subtitle, subtext, auth, keepUser }) => {

    const navigate = useNavigate();

    const [data, setData] = useState({ username: '', password: '' });

    const handleSignIn = async () => {        
        let values = { LoginPhone: data.username, LoginPassword: data.password };
        let response = await signIn(values);        
        keepUser(response.data);
        navigate('/dashboard');
    }

    const handleChange = useCallback((e, key) => {
        setData(prevState => ({
            ...prevState,
            [key]: e.target.value
        }));
    }, []);

    return (
        <>
            {title && (
                <Typography fontWeight="700" variant="h2" mb={1}>
                    {title}
                </Typography>
            )}

            <Stack>
                <Box>
                    <Typography variant="subtitle1" fontWeight={600} component="label" htmlFor='username' mb="5px">
                        Username
                    </Typography>
                    <TextField
                        value={data.username}
                        onChange={(e) => handleChange(e, "username")}
                        variant="outlined"
                        fullWidth
                    />
                </Box>
                <Box mt="25px">
                    <Typography variant="subtitle1" fontWeight={600} component="label" htmlFor='password' mb="5px">
                        Password
                    </Typography>
                    <CustomTextField
                        id="password"
                        type="password"
                        value={data.password}
                        onChange={(e) => handleChange(e, "password")}
                        variant="outlined"
                        fullWidth
                    />
                </Box>
                <Stack justifyContent="space-between" direction="row" alignItems="center" my={2}>
                    <FormGroup>
                        <FormControlLabel
                            control={<Checkbox defaultChecked />}
                            label="Remember this Device"
                        />
                    </FormGroup>
                    <Typography
                        component={Link}
                        to="/"
                        fontWeight="500"
                        sx={{
                            textDecoration: 'none',
                            color: 'primary.main',
                        }}
                    >
                        Forgot Password ?
                    </Typography>
                </Stack>
            </Stack>
            <Box>
                <Button
                    color="primary"
                    variant="contained"
                    size="large"
                    fullWidth
                    onClick={handleSignIn}
                    type="submit"
                >
                    Sign In
                </Button>
            </Box>
            {subtitle}
        </>
    );
}

const mapStateToProps = (state) => ({
    auth: state.auth,
});

export default connect(mapStateToProps, actions)(React.memo(AuthLogin));
