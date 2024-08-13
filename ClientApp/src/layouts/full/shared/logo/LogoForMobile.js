import { Link } from 'react-router-dom';
import { ReactComponent as LogoDark } from 'src/assets/images/logos/dark-logo.svg';
import { ReactComponent as DeliManager} from 'src/assets/images/logos/DeliManager.svg';
import { ReactComponent as DeliManagerLogo} from 'src/assets/images/logos/DeliManagerLogo.svg';
import { Hidden, styled } from '@mui/material';
import { Block } from '@mui/icons-material';

const LinkStyled = styled(Link)(() => ({
  // height: '70px',
  // width: '70px',
  overflow: 'hidden',
  display: 'block',
}));

const LogoForMobile = () => {
  return (    
    <LinkStyled to="/">
      <DeliManagerLogo height={70}/>      
    </LinkStyled>    
    
  )
};

export default LogoForMobile;
