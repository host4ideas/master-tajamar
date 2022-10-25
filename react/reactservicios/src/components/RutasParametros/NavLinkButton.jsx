import { useHistory } from "react-router-dom";
import Button from "react-bootstrap/Button";

export default function NavLinkButton({ path }) {
    const history = useHistory();

    function handleClick(path) {
        history.push(path);
    }

    return (
        <Button
            variant="outline-light"
            size="lg"
            onClick={() => handleClick(path)}
        >
            {path}
        </Button>
    );
}
